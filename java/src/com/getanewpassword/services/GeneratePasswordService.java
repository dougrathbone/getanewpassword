package com.getanewpassword.services;

import com.getanewpassword.models.GeneratePasswordOptions;

import java.io.IOException;

public interface GeneratePasswordService  {
    String GeneratePassword(GeneratePasswordOptions options) throws IOException;

    String BuildPassword(String[] wordsArray, GeneratePasswordOptions options);

    String SelectRandomWord(String[] wordsArray, boolean pascalCase);
}
