#pragma once

/// Functionality to interact with the file system.
namespace FileSystem {
    /**
     * Check if a file exists.
     * Works for directories as well.
     * @param filename Filename (either relative or absolute) to check.
     * @return Whether the file exists
     */
    bool FileExists(const char* filename);
}
