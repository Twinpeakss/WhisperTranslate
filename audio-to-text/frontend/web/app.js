const transcriptionButton = document.getElementById('transcriptionButton');
const audioInput = document.getElementById('audioInput');
const resultArea = document.getElementById('resultArea');
const loadingIndicator = document.getElementById('loadingIndicator');

transcriptionButton.addEventListener('click', async () => {
    const audioFile = audioInput.files[0];
    if (!audioFile) {
        alert('Please select an audio file.');
        return;
    }

    loadingIndicator.style.display = 'block';
    resultArea.value = '';

    const formData = new FormData();
    formData.append('audioFile', audioFile);

    try {
        const response = await fetch('/api/transcribe', {
            method: 'POST',
            body: formData
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const result = await response.json();
        resultArea.value = result.transcribedText;
    } catch (error) {
        console.error('Error:', error);
        alert('An error occurred while transcribing the audio.');
    } finally {
        loadingIndicator.style.display = 'none';
    }
});