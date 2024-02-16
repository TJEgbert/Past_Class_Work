set(CMAKE_INCLUDE_CURRENT_DIR_IN_INTERFACE ON)

set(TARGET_NAME main)      # program name
set(LIB_NAME mylib)      # lib name

# Create a Shared Library
add_library(${LIB_NAME}
  SHARED
    cars.h
    cars.cpp
  )
# 
# Note: In windows, the executable name will be: ca1.exe
add_executable(${TARGET_NAME} main.cpp)
target_link_libraries(${TARGET_NAME} ${LIB_NAME}) # Link Library