package com.getanewpassword.controllers;

import com.getanewpassword.models.GeneratePasswordOptions;
import com.getanewpassword.services.GeneratePasswordService;
import com.getanewpassword.services.GeneratePasswordServiceImpl;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.context.ServletContextAware;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.ServletContext;
import java.io.IOException;

@Controller
public class HomeController  implements ServletContextAware {
    String wordFilePath;

    @RequestMapping("/")
    public ModelAndView index() throws IOException {
        GeneratePasswordService svc = new GeneratePasswordServiceImpl(wordFilePath);
        String password = svc.GeneratePassword(new GeneratePasswordOptions());

        return new ModelAndView("index", "newPassword", password);
    }

    @RequestMapping(value = "/api/generatepassword", method = RequestMethod.GET, produces = "application/json")
    @ResponseBody
    public String generatePassword() throws IOException {
        GeneratePasswordService svc = new GeneratePasswordServiceImpl(wordFilePath);
        String password = svc.GeneratePassword(new GeneratePasswordOptions());
        return "{\"Password\" : \"" + password + "\"}";
    }

    @Override
    public void setServletContext(ServletContext servletCtx){
        wordFilePath = servletCtx.getRealPath("content/wordlist.txt");
    }
}