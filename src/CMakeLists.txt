set(SRCS
        main.cpp
        FileSystem.cpp
        Level.cpp
        Mouse.cpp
        Vec2.cpp
        Timing.cpp
    )

set(HEADERS
        configuration.hpp
        FileSystem.hpp
        Level.hpp
        Mouse.hpp
        Vec2.hpp
        Timing.hpp
    )

create_directory_groups(${SRCS} ${HEADERS})

add_executable(SquareCellsTAS ${SRCS} ${HEADERS})
set_property(TARGET SquareCellsTAS PROPERTY CXX_STANDARD 11)
set_property(TARGET SquareCellsTAS PROPERTY CXX_STANDARD_REQUIRED ON)
