# Audio to Text Application

This project is an "Audio to Text" application that allows users to upload audio files and receive transcriptions in text format. The application is structured with a clear separation between the backend and frontend components.

## Project Structure

```
audio-to-text
├── AudioToText.sln
├── .gitignore
├── README.md
├── backend
│   └── AudioToText.Api
│       ├── Controllers
│       │   └── TranscriptionController.cs
│       ├── Services
│       │   └── TranscriptionService.cs
│       ├── Models
│       │   └── TranscriptionResult.cs
│       ├── Program.cs
│       └── AudioToText.Api.csproj
└── frontend
    └── web
        ├── index.html
        ├── app.js
        └── styles.css
```

## Backend

The backend is built using ASP.NET Core and exposes an API for transcribing audio files.

### Running the Backend

1. Navigate to the `backend/AudioToText.Api` directory.
2. Restore the dependencies:
   ```
   dotnet restore
   ```
3. Run the application:
   ```
   dotnet run
   ```
4. The API will be available at `http://localhost:5000/api/transcribe`.

## Frontend

The frontend is a simple web interface that allows users to interact with the backend API.

### Running the Frontend

1. Navigate to the `frontend/web` directory.
2. Open `index.html` in a web browser.
3. Use the interface to upload audio files and submit transcription requests.

## Additional Information

- Ensure that you have the necessary permissions and API keys to access any external services used for transcription.
- The project can be extended with additional features such as user authentication, history of transcriptions, and more.

## License

This project is licensed under the MIT License - see the LICENSE file for details.