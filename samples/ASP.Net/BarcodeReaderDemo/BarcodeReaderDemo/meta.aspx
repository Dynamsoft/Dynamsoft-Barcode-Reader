
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="robots" content="index, follow" />
<meta name="distribution" content="global" />
<meta name="rating" content="General" />
<meta name="language" content="en-us" />
<meta name="location" content="CA, BC, Vancouver" />
<meta name="googlebot" content="index, follow" />
<meta name="revisit-after" content="7 days" />
<meta name="resource-type" content="document" />
<meta name="distribution" content="global" />
<meta name="classification" content="" />
<meta name="viewport" content="width=device-width, maximum-scale=1.0"/>
<link rel="stylesheet" href="Css/basis.css?ver=2.0"/>
<%
	if(Request.Url.Host != null && (Request.Url.Host =="www.dynamictwain.com" ||Request.Url.Host =="dynamictwain.com") )
	{
		if(Request.Url.PathAndQuery != null && Request.Url.PathAndQuery !="/index.aspx")
		{
			string strPathAndQuery = Request.Url.PathAndQuery;
			Response.Redirect("http://www.dynamsoft.com" + strPathAndQuery);
		}
		else		
		{
			Response.Redirect("http://www.dynamsoft.com");
		}
	}
%>
<script src="Scripts/jquery-1.11.2.js"></script>
<script src="Scripts/ds-jquery.js"></script>
