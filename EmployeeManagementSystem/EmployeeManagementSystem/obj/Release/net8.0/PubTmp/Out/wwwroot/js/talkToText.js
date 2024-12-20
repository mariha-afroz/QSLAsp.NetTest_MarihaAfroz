document.addEventListener('DOMContentLoaded', function () {
    var isMicrophoneEnabled = false;

    var speechBtn = document.getElementById('speechBtn');
    if (speechBtn) {
        speechBtn.addEventListener('click', function () {
            isMicrophoneEnabled = !isMicrophoneEnabled;

            var micIcon = this.querySelector('i');
            if (isMicrophoneEnabled) {
                micIcon.classList.add('active');
                micIcon.style.color = 'red';
            } else {
                micIcon.classList.remove('active');
                micIcon.style.color = 'white';
            }
        });
    } else {
        console.error("Element with ID 'speechBtn' not found.");
    }
    //document.getElementById('speechBtn').addEventListener('click', function () {
    //    isMicrophoneEnabled = !isMicrophoneEnabled;

    //    var micIcon = this.querySelector('i');
    //    if (isMicrophoneEnabled) {
    //        micIcon.classList.add('active');
    //        micIcon.style.color = 'red';
    //    } else {
    //        micIcon.classList.remove('active');
    //        micIcon.style.color = 'white';
    //    }
    //}); 
    document.addEventListener('click', function (event) {
        if (isMicrophoneEnabled && event.target.tagName.toLowerCase() === 'textarea') {
            speakToText(event.target.id);
        }
    });
});

function speakToText(id) {
    if ('webkitSpeechRecognition' in window) {
        var recognition = new webkitSpeechRecognition();
        var input_element = document.getElementById(id);

        recognition.continuous = true;
        recognition.interimResults = true;
        recognition.lang = 'en-US';

        recognition.onresult = function (event) {
            var final_value = '';

            for (var i = event.resultIndex; i < event.results.length; ++i) {
                if (event.results[i].isFinal) {
                    final_value += event.results[i][0].transcript;
                }
            }

            input_element.value += final_value;
        };

        recognition.start();

        input_element.addEventListener('blur', function () {
            recognition.stop();
        });
    }
}
