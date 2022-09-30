'use strict';

$(document).ready(function () {

    (() => {

        // Track Section
        SiteHelper.AjaxHelper.contentLoader(
            'data-tracks-container',
            (track, i) => `<div class="single_player_container">
                            <h4>${track.Title}</h4>
                            <div class="jp-jplayer jplayer" data-ancestor=".jp_container_${(i + 1)}" data-url="${track.AudioUrl}"></div>
                            <div class="jp-audio jp_container_${(i + 1)}" role="application" aria-label="media player">
                                <div class="jp-gui jp-interface">
                                    <!-- Player Controls -->
                                    <div class="player_controls_box">
                                        <button class="jp-play player_button" tabindex="0"></button>
                                    </div>
                                    <!-- Progress Bar -->
                                    <div class="player_bars">
                                        <div class="jp-progress">
                                            <div class="jp-seek-bar">
                                                <div>
                                                    <div class="jp-play-bar">
                                                        <div class="jp-current-time" role="timer" aria-label="time">0:00</div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="jp-duration ml-auto" role="timer" aria-label="duration">00:00</div>
                                    </div>
                                    <!-- Volume Controls -->
                                    <div class="jp-volume-controls">
                                        <button class="jp-mute" tabindex="0"><iclass="fa fa-volume-down"></i></button>
                                        <div class="jp-volume-bar">
                                            <div class="jp-volume-bar-value" style="width: 0%;"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>`,
            SingleJpPlayer.init,
            new SiteHelper.AjaxHelper.ajaxObject('api/TrackApi?inputCount=10')).start();

        //  Event Section
        SiteHelper.AjaxHelper.contentLoader(
            'data-artists-container',
            (album, i) => `<div class="col-lg-4">
                                <div class="event__item">
                                    <div class="event__item__pic">
                                        <object data="${album.PhotoUrl == '' ? '_' : album.PhotoUrl}" type="image/png">
                                            <img src="/Content/Assets/img/discography/no-photo.png" alt="${album.Name}">
                                        </object>
                                        <div class="tag">
                                            <span style="font-size: 18px;">${album.Name}</span>
                                        </div>
                                    </div>
                                    <div class="event__item__text">
                                        <h5>${album.ArtistGenres.length ? album.ArtistGenres.join(', ') : 'No Genre'}</h5>
                                        <p><i class="fa fa-map-marker"></i> ${album.Country}</p>
                                    </div>
                                </div>
                            </div>`,
            () => {
                $(".event__slider").owlCarousel({
                    loop: true,
                    margin: 0,
                    items: 3,
                    dots: false,
                    nav: true,
                    navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
                    smartSpeed: 1200,
                    autoHeight: false,
                    autoplay: true,
                    responsive: { 992: { items: 3, }, 768: { items: 2, }, 0: { items: 1, }, }
                });
            },
            new SiteHelper.AjaxHelper.ajaxObject('api/ArtistApi')).start();
    })();
});