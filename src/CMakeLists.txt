set(SRCS
        main.cpp
    )

set(HEADERS
        
    )

create_directory_groups(${SRCS} ${HEADERS})

add_executable(SquareCellsTAS ${SRCS} ${HEADERS})
set_property(TARGET SquareCellsTAS PROPERTY CXX_STANDARD 11)
set_property(TARGET SquareCellsTAS PROPERTY CXX_STANDARD_REQUIRED ON)
