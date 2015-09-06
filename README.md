# Selenium screenshot dashboard

==============

## What is Selenium screenshot dashboard?

Seleniumscreenshot dashboard is a website to view the seleniumscreenshots that are made with [Selenium storage provider](https://github.com/marcoippel/Selenium-storage-provider)

## How to get started?

* Download the project.
* Install the website. 
* Add and configure [Selenium storage provider](https://github.com/marcoippel/Selenium-storage-provider) to your selenium test project.
* Add a application setting StorageConnectionString and BlobContainer:
```
<appSettings>
  <add key="StorageConnectionString" value="{your blobstorage connectionstring}" />
  <add key="BlobContainer" value="{your blobstorage container name}"/>
</appSettings>
```
## Screenshots
![Alt text](/SeleniumScreenshotViewer/Images/overview-screen.jpg?raw=true)
![Alt text](/SeleniumScreenshotViewer/Images/detailscreen.jpg?raw=true)
