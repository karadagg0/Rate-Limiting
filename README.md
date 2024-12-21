# Rate Limiting Algorithms in .NET

This project demonstrates the implementation of rate limiting in a .NET application. It covers four different rate-limiting algorithms to control the number of requests a user can make within a specified time window.

## Algorithms Implemented

### 1. **Fixed Window**
- The fixed window algorithm divides time into fixed-sized intervals and limits the number of requests allowed within each interval. Once the limit is exceeded, further requests are denied until the next window.

### 2. **Sliding Window**
- In this approach, the window "slides" as time progresses. Requests are counted within a sliding time frame, ensuring smoother rate limiting and reducing the chances of sudden spikes of requests.

### 3. **Token Bucket**
- The token bucket algorithm allows a burst of requests up to a defined capacity. Tokens are refilled at a steady rate, and each request requires a token. If no tokens are available, the request is rejected.

### 4. **Concurrency**

## Features
- Implements multiple rate-limiting algorithms.
- Configurable request limits and time windows.
- Can be used to throttle API endpoints and control traffic.

## Setup

### Prerequisites
- .NET 7 SDK or later.
- Visual Studio or VS Code.

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/karadagg0/Rate-Limiting.git
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

3. Run the application:
    ```bash
    dotnet run
    ```
