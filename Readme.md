
## **PinSalvare** - Pinterest pin (photo or video) downloader telegram bot.



## Tech Stack

**Server:** C#, .NET, Azure Functions

**Bot Interactions:** [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot)

**Pinterest APIs:** [Rapid.Api/PinterestVideoAndImageDownloader](https://rapidapi.com/vikas5914/api/pinterest-video-and-image-downloader)


## Project overview

Pinterest is a fantastic platform for discovering and sharing ideas, but downloading videos from Pinterest can be a hassle. Most available websites for this purpose are overloaded with ads, requiring users to watch multiple ads just to download a single video. Frustrated with this experience, I decided to create my own solution: a Telegram bot that simplifies the process.

Technology Stack
As a .NET developer, I leveraged my existing skills to bring this idea to life. I integrated a Pinterest video and image downloader API (available on RapidAPI, with 200 free requests per month) and used a NuGet package to interact with the Telegram API. After successfully connecting these services, the bot was up and running seamlessly on my local machine.

Challenges and Solutions
However, running the bot locally posed a challenge. Telegram bots can operate in two ways:

    1. Long Polling: Continuously checks for new messages, requiring a server to run 24/7.

    2. Webhooks: Automatically triggered by Telegram when a new message arrives, eliminating the need for a constantly running server.
Since I intended the bot for personal use, I opted for the more efficient and cost-effective webhook approach, avoiding the need for a 24/7 server.

Server Architecture
To further streamline the solution, I explored Azure Functions, which allowed me to run serverless code in the cloud. After learning how to integrate Azure Functions with my .NET code, I created an HTTP-triggered function and linked it to the Telegram webhook. The result? A fully functional bot without the overhead of maintaining a dedicated server.

And it worked! 🎉

## Environment Variables

To run this project, you will need to add the following environment variables

`BotToken` 

`ApiEndpoint`

`ApiHeaderKey`

`ApiHeaderHost`

`AllowedUsers`


## 🔗 Links
[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://github.com/alistein)
[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/ali-aliyev-57393a168/)


