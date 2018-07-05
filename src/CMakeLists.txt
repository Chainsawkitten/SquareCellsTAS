set(SRCS
        main.cpp
        FileSystem.cpp
        Level.cpp
    )

set(HEADERS
        FileSystem.hpp
        Level.hpp
    )

create_directory_groups(${SRCS} ${HEADERS})

add_executable(SquareCellsTAS ${SRCS} ${HEADERS})
set_property(TARGET SquareCellsTAS PROPERTY CXX_STANDARD 11)
set_property(TARGET SquareCellsTAS PROPERTY CXX_STANDARD_REQUIRED ON)
