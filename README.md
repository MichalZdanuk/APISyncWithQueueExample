# 📦 APISyncWithQueueExample

Simple project for skills self improvement purposes: **.NET API with RabbitMQ Messaging** project! 🎉

This project consists of two small .NET APIs designed to demonstrate message publishing and consumption using RabbitMQ. The primary goal is to learn the basics of configuring message queues and enabling communication between systems. 

## 🚀 Overview

- **System A**: Publishes messages to a RabbitMQ exchange.
- **System B**: Consumes messages from the RabbitMQ queue.

## 🛠️ Technologies Used

- **.NET 8.0**
- **RabbitMQ**
- **MS SQL**

### 📐 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/products/docker-desktop/)

### ⚙️ Setup Instructions

1. Clone the repository:
```bash
git clone git@github.com:MichalZdanuk/APISyncWithQueueExample.git
cd APISyncWithQueueExample
```
2. Run docker compose with Rabbit and SQL Databases for SystemA and SystemB:
```bash
docker-compose up -d
```
3. Run RabbitMQ infrastructure initializer to setup exchange with queues in separate terminal:
```bash
cd RabbitMQInitializer
dotnet build
dotnet run
```
4. Run System A:
```bash
cd SystemA.API
dotnet build
dotnet run
```
5. Run System B:
```bash
cd SystemB.API
dotnet build
dotnet run
```

### 📜 Note

- RabbitMQ UI: localhost:15672
- System A: localhost:5052
- System B: localhost:5053
