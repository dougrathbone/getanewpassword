package com.getanewpassword.services;

import com.getanewpassword.models.GeneratePasswordOptions;
import com.sun.xml.internal.fastinfoset.util.CharArray;

import java.io.IOException;
import java.util.Random;

public class GeneratePasswordServiceImpl implements GeneratePasswordService {

    private static String[] wordCache;
    FileOperationService fileService;
    String filePath;
    Random random;


    public GeneratePasswordServiceImpl(String path){
        fileService = new FileOperationServiceImpl();
        filePath = path;
        random = new Random();
    }

    @Override
    public String GeneratePassword(GeneratePasswordOptions options) throws IOException {
        if (wordCache == null) loadWords();
        return BuildPassword(wordCache, options);
    }

    private void loadWords() throws IOException {
        String words = fileService.ReadAllText(filePath);
        wordCache = words.split(",");
    }

    @Override
    public String BuildPassword(String[] wordsArray, GeneratePasswordOptions options) {

        StringBuilder output = new StringBuilder();
        for (int x = 0; x < options.MinWords; x++)
        {
            output.append(SelectRandomWord(wordsArray, options.AddUppercase) + options.Separator);
        }
        if (options.AddNumber) output.append(random.nextInt(9));
        return output.toString();
    }

    @Override
    public String SelectRandomWord(String[] wordsArray, boolean pascalCase) {
        int rand = random.nextInt(wordsArray.length-1);
        String word = wordsArray[rand].trim();
        char[] characters = word.toCharArray();
        return Character.toUpperCase(characters[0]) + word.substring(1, word.length() - 1);
    }
}
