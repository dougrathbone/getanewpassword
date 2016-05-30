package com.getanewpassword.services;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class FileOperationServiceImpl implements FileOperationService {
    @Override
    public String ReadAllText(String path) throws IOException {
        Stream<String> lines = Files.lines(Paths.get(path));
        String output = lines.collect(Collectors.joining(","));
        return output;
    }
}
