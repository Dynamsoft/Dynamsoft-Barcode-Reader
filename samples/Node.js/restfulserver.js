// http://restify.com/#content-negotiation
var restify = require('restify');
var socketio = require('socket.io');
var fs = require('fs');
var io = socketio.listen(server);
var server = restify.createServer();
var dbr = require('./build/Release/dbr');

server.use(restify.bodyParser());

server.get(/.*/, restify.serveStatic({
  directory: __dirname,
  default: 'index.html'
}));

function respond(req, res, next) {
  res.send('hello ' + req.params.name);
  res.writeHead(200);
  res.end();
  next();
}

server.post('/dbr', function create(req, res, next) {
  // console.log(req);
  fs.writeFile("log.txt", req.body, function(err) {
    if (err) {
      return console.log(err);
    }

    console.log("Base64 saved!");
  });

  var data = new Buffer(req.body, 'base64');
  // var file = __dirname + '/' + new Date().getTime() + '.png';
  var file = __dirname + '/' + 'test.png';

  fs.writeFile(file, data, function(err) {
    dbr.decodeFile(
      file,
      function(msg) {
        var final_result = "";
        var hasResult = false;
        for (index in msg) {
          hasResult = true;
          var result = msg[index]
          final_result += "value: " + result['value'] + "; ";
          console.log(result['format']);
          console.log(result['value']);
          console.log("##################");
        }

        if (!hasResult) {
          final_result = "No barcode detected";
        }

        fs.unlink(file, function(err) {
          console.log('Removed cached: ' + file);
        });
        res.send(200, final_result);
        next();
      }
    );
  });
});

server.get('/', function indexHTML(req, res, next) {

  var fileName = __dirname + '/restful.htm';
  console.log('get: ' + fileName);
  fs.readFile(fileName, function(err, data) {
    console.log("read file " + err);
    if (err) {

      next(err);
      return;
    }
    console.log('successful');
    res.setHeader('Content-Type', 'text/html');
    res.writeHead(200);
    res.end(data);
    next();
  });
});


io.sockets.on('connection', function(socket) {
  socket.emit('news', {
    hello: 'world'
  });
  socket.on('my other event', function(data) {
    console.log(data);
  });
});

server.listen(8080, function() {
  console.log('socket.io server listening at %s', server.url);
});
