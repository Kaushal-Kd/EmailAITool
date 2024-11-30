# AI Contact Extractor

## Description

**AI Contact Extractor** is an AI-powered tool designed to extract contact information from email bodies. Using Natural Language Processing (NLP) and machine learning techniques, this tool identifies and extracts important contact details such as email addresses, phone numbers, and social media profiles from text-heavy email content. This can be particularly useful for automating contact management and streamlining workflows.

The tool is built using **C#** and integrates **Docker** to ensure easy deployment and scalability.

## Features

- **AI-Powered Extraction**: Uses machine learning algorithms to extract key contact details (emails, phone numbers, etc.) from email body text.
- **NLP-Based Parsing**: Natural Language Processing (NLP) is used to accurately parse and identify contact information.
- **Docker Integration**: The application is containerized using Docker, making it easy to deploy and run in any environment.
- **Extensibility**: Easily extendable to support additional contact types or parsing rules as needed.

## Tech Stack

- **C#**: Main programming language used to build the tool.
- **Docker**: Containerization for easy deployment and scalability.
- **AI/ML Models**: Used for extracting structured data from unstructured email text.
- **.NET Framework/Core**: Framework for developing the application.

## Architecture Overview

This project utilizes a combination of **AI/ML** models and **NLP techniques** to extract contact information from unstructured email bodies. Key components include:

- **Email Parser**: Extracts raw email content and passes it to the NLP module.
- **NLP Processor**: Processes the email body using pre-trained machine learning models to identify relevant contact information.
- **Dockerized Application**: The entire application is containerized with Docker, ensuring portability and ease of deployment.

## Installation

### Prerequisites

Before running the tool, ensure you have the following installed:

- **.NET SDK 7.0** or later
- **Docker**: Ensure Docker is installed and running on your machine to use the containerized version.

### Setup Instructions

1. Clone this repository to your local machine:

    ```bash
    git clone https://github.com/<your-github-username>/AI-Contact-Extractor.git
    ```

2. Navigate to the project directory:

    ```bash
    cd AI-Contact-Extractor
    ```

3. Restore the project dependencies:

    ```bash
    dotnet restore
    ```

4. Build and run the application locally (without Docker) to test it out:

    ```bash
    dotnet run
    ```

    Alternatively, you can run the application using Docker.

### Running with Docker

1. Build the Docker image:

    ```bash
    docker build -t ai-contact-extractor .
    ```

2. Run the Docker container:

    ```bash
    docker run -p 8080:80 ai-contact-extractor
    ```

The application should now be running in a Docker container. You can interact with it via HTTP requests, depending on how the API is set up.

## Usage

### Example Use Case

- **Input**: An email body containing contact details, such as:

    ```
    Hello John,

    You can reach me at jane.doe@example.com or via my phone at (123) 456-7890. Feel free to connect with me on LinkedIn too!

    Best regards,
    Jane
    ```

- **Output**: Extracted contact information:

    ```json
    {
        "email": "jane.doe@example.com",
        "phone": "(123) 456-7890",
        "social": "LinkedIn"
    }
    ```

### API Endpoints

The tool exposes an API to extract contact details from an email body.

- **POST /extract-contact-info**  
  - **Request body**: JSON containing the email body text.
  - **Response**: JSON with extracted contact information.

    Example Request:
    ```json
    {
      "email_body": "Hello John, you can contact me at jane.doe@example.com."
    }
    ```

    Example Response:
    ```json
    {
      "email": "jane.doe@example.com"
    }
    ```

## Contributing

If you'd like to contribute to this project, please follow these steps:

1. Fork this repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to your branch (`git push origin feature/your-feature`).
5. Open a pull request with a description of your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- **AI and NLP Techniques**: The machine learning models and natural language processing techniques used to identify and extract contact information.
- **Docker**: Containerization tool that simplifies deployment and scalability.
- **C# and .NET**: Frameworks that power the application.
