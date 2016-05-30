package com.getanewpassword.services;

import java.io.IOException;

public interface FileOperationService {
    String ReadAllText(String path) throws IOException;
}
