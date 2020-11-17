# How to Build the Sample

## Windows

```
mkdir build
cd build

// x86
cmake -DCMAKE_GENERATOR_PLATFORM=x86 ..

// x64
cmake -DCMAKE_GENERATOR_PLATFORM=x64 ..

cmake --build . --config release
```

## Linux

```
mkdir build
cd build
cmake ..
cmake --build . --config release 
```

## ARM32

```
mkdir build
cd build
cmake -DBUILD_ARM=arm32 .. 
cmake --build . --config release 
```