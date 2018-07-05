#include "FileSystem.hpp"

#include <sys/stat.h>

namespace FileSystem {
    bool FileExists(const char* filename) {
        struct _stat buf;
        int result = _stat(filename, &buf);
        return result == 0;
    }
}
