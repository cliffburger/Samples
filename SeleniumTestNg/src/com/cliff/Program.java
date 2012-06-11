package com.cliff;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxProfile;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.io.File;

public class Program {

    public static void main(String[] args){

        System.setProperty("webdriver.chrome.driver", "d:\\bin\\chromedriver.exe");
        RemoteWebDriver driver =  new ChromeDriver()  ;
        driver.get("http://google.com");
        System.out.println(driver.getTitle());
        driver.quit();

    }
}
