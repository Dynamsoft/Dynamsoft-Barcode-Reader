project(BatchDecode)
cmake_minimum_required(VERSION 3.6)
option(BUILD_ARM "This is a default option for BUILD_ARM" OFF)

if (CMAKE_HOST_WIN32)
    if(CMAKE_CL_64)
        link_directories("${PROJECT_SOURCE_DIR}/../../../lib/Windows/x64") 
    else()
        link_directories("${PROJECT_SOURCE_DIR}/../../../lib/Windows/x86") 
    endif()
elseif(CMAKE_HOST_APPLE)
    message(STATUS 'build for macOS')
elseif(CMAKE_HOST_UNIX)
    if(${BUILD_ARM} STREQUAL "arm32")
        set(CMAKE_C_COMPILER arm-linux-gnueabihf-gcc)
        set(CMAKE_CXX_COMPILER arm-linux-gnueabihf-g++)
        set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -D__ARM_NEON__ -mfpu=neon")
        link_directories("${PROJECT_SOURCE_DIR}/../../../lib/ARM32") 
    elseif(${BUILD_ARM} STREQUAL "arm64")
        set(CMAKE_C_COMPILER aarch64-linux-gnu-gcc)
        set(CMAKE_CXX_COMPILER aarch64-linux-gnu-g++)
        set(CMAKE_AR aarch64-linux-gnu-ar)
        message(STATUS 'build for arm64')
    else()
        set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -O2 -std=c++11 -fPIC ")
        set(CMAKE_EXE_LINKER_FLAGS "${CMAKE_EXECUTABLE_LINKER_FLAGS} -O2 -fvisibility=hidden -fvisibility-inlines-hidden -Wl,-rpath,'$ORIGIN' -static-libgcc -static-libstdc++ -s")
        link_directories("${PROJECT_SOURCE_DIR}/../../../lib/Linux") 
    endif()
endif()

include_directories("${CMAKE_CURRENT_SOURCE_DIR}/../../../include")

file(GLOB FILE_SRCS
${CMAKE_CURRENT_SOURCE_DIR}/BatchDecode/BatchDecode.cpp
${CMAKE_CURRENT_SOURCE_DIR}/BatchDecode/BarcodeStatisticsRecorder.cpp
${CMAKE_CURRENT_SOURCE_DIR}/BatchDecode/BarcodeFileReader.cpp
${CMAKE_CURRENT_SOURCE_DIR}/BatchDecode/DbrBarcodeFileReader.cpp
#${CMAKE_CURRENT_SOURCE_DIR}/BatchDecode/stdafx.cpp
)
add_executable(BatchDecode ${FILE_SRCS})
set_target_properties(BatchDecode PROPERTIES SKIP_BUILD_RPATH TRUE)
if(CMAKE_HOST_WIN32)
    if(CMAKE_CL_64)
        target_link_libraries (BatchDecode "DBRx64")
    else()
        target_link_libraries (BatchDecode "DBRx86")
    endif()
else()
    target_link_libraries (BatchDecode "DynamsoftBarcodeReader")
endif()

# copy libs to build dir
if (CMAKE_HOST_WIN32)
    if(CMAKE_CL_64)
        add_custom_command(TARGET BatchDecode POST_BUILD 
            COMMAND ${CMAKE_COMMAND} -E copy_directory
            "${PROJECT_SOURCE_DIR}/../../../lib/Windows/x64"    
            $<TARGET_FILE_DIR:BatchDecode>)
    else()
        add_custom_command(TARGET BatchDecode POST_BUILD 
        COMMAND ${CMAKE_COMMAND} -E copy_directory
        "${PROJECT_SOURCE_DIR}/../../../lib/Windows/x86"    
        $<TARGET_FILE_DIR:BatchDecode>)
    endif()
elseif(CMAKE_HOST_APPLE)
    message(STATUS 'build for macOS')
elseif(CMAKE_HOST_UNIX)
    if(${BUILD_ARM} STREQUAL "arm32")
        add_custom_command(TARGET BatchDecode POST_BUILD 
        COMMAND ${CMAKE_COMMAND} -E copy_directory
        "${PROJECT_SOURCE_DIR}/../../../lib/ARM32"     
        $<TARGET_FILE_DIR:BatchDecode>)
    elseif(${BUILD_ARM} STREQUAL "arm64")
        message(STATUS 'build for arm64')
    else()
        add_custom_command(TARGET BatchDecode POST_BUILD 
        COMMAND ${CMAKE_COMMAND} -E copy_directory
        "${PROJECT_SOURCE_DIR}/../../../lib/Linux"     
        $<TARGET_FILE_DIR:BatchDecode>)
    endif()
endif()
