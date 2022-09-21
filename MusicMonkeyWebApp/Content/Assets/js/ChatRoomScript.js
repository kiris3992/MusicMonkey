          $(function () {
                var chat = $.connection.chatHub;
                chat.client.addNewMessageToPage = function (name, message) {
                    const className = $('#displayname').val() == name ? 'chat-message chat-user_message' : 'chat-message';

                    $('#chat-body').append(
                        `<p class="${className}"><span>${htmlEncode(name).bold()}: </span>${htmlEncode(message).fontcolor(color = "purple")}  <span>${getTime().fontsize(1).fontcolor(color = "gray")}</span></p>`
                    );
                    $(document).ready(function () {
                        $('#chat-body').animate({ scrollTop: 1000000 }, 800);
                    })
                };
                $('#displayname').val(prompt('Enter your nickname:', ''));
                $('#message').focus();
                $.connection.hub.start().done(function () {
                    $('#sendmessage').click(function () {
                        chat.server.send($('#displayname').val(), $('#message').val());
                        $('#message').val('').focus();
                    });
                });
            });

            function htmlEncode(value) {
                var encodedValue = $('<div />').text(value).html();
                return encodedValue;
            }

            $(document).ready(() => {
                $('.chat-popup').click(() => {
                    $('.chat-container').slideToggle("slow");
                });
            })

            function getTime() {
                let today = new Date();
                hours = today.getHours();
                minutes = today.getMinutes();

                if (hours < 10) {
                    hours = "0" + hours;
                }
                if (minutes < 10) {
                    minutes = "0" + minutes;
                }
                let time = hours + ":" + minutes;
                return time;
            }