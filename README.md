# 📦 APISyncWithQueueExample

Simple project for skills self improvement purposes: **.NET API with RabbitMQ Messaging** project! 🎉

This project consists of two small .NET APIs (written in Clean Architecture) designed to demonstrate message publishing and consumption using RabbitMQ. The primary goal is to learn the basics of configuring message queues and enabling communication between systems manually, without help of external packages like MassTransit or Wolverine. 

## 🚀 Overview

- **System A**: Publishes messages to a RabbitMQ exchange.
- **System B**: Consumes messages from the RabbitMQ queue.

## 🏛️ Architecture

![ApiSyncArchitectureDiagram](https://github.com/user-attachments/assets/7edd9b5f-21ef-43f5-b1d3-946bfb1d84be)

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
2. Run docker compose with whole app configured:
```bash
docker-compose up -d
```
3. Run RabbitMQ infrastructure initializer to setup exchange with queues in separate terminal:
```bash
cd RabbitMQInitializer
dotnet build
dotnet run
```

Below is a table specifying ports on which is available each component, either for **localhost** or when running in **Docker**:

| Service         | Ports          | Description                                                                |
|-----------------|----------------|----------------------------------------------------------------------------|
| **System A**    | 6000 / 6060    | System responsible for producing entities and publishing event on queue    |
| **System B**    | 6001 / 6061    | Receiver system that stores events about performed operations in system A  |
| **Rabbit MQ**   | 5672 / 15672   | Message broker transporting events from Publisher (A) to Subscriber (B)    |
