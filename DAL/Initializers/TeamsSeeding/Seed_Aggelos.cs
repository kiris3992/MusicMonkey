using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Initializers.TeamsSeeding
{
    public class Seed_Aggelos : AbsTeamSeeder, ITeamSeeder
    {
        public List<Artist> GetArtists()
        {
            #region Aggelos Seeding
            #region Seeding Artists
            Artist aa1 = new Artist { Name = "D'Angelo", Country = Country.USA, CareerStartDate = new DateTime(1991, 1, 1), PhotoUrl = "DANGELOPhotoUrl.jpg", ArtistGenres = new List<Genre> { rnb, pop } };
            Artist aa2 = new Artist { Name = "Above & Beyond", Country = Country.United_Kingdom, CareerStartDate = new DateTime(2000, 1, 1), PhotoUrl = "Above&BeyondPhotoUrl.jpg", ArtistGenres = new List<Genre> { trance, house } };
            Artist aa3 = new Artist { Name = "Migos", Country = Country.USA, CareerStartDate = new DateTime(2008, 1, 1), PhotoUrl = "MigosPhotoUrl.jpg", ArtistGenres = new List<Genre> { hipHop, trap } };
            Artist aa4 = new Artist { Name = "Unknown Artist", CareerStartDate = new DateTime(1901, 1, 1), PhotoUrl = "UnknownPhotoUrl.jpg" };
            Artist aa5 = new Artist { Name = "Axel Willner", Country = Country.Sweden, CareerStartDate = new DateTime(1996, 1, 1), PhotoUrl = "AxelWillnerPhotoUrl.jpg", ArtistGenres = new List<Genre> { techno, electronic } };
            Artist aa6 = new Artist { Name = "Marvin Gaye", Country = Country.USA, CareerStartDate = new DateTime(1957, 1, 1), PhotoUrl = "Marvin_GayePhotoUrl.jpg", ArtistGenres = new List<Genre> { soul } };
            Artist aa7 = new Artist { Name = "Michael Jackson", Country = Country.USA, CareerStartDate = new DateTime(1964, 1, 1), PhotoUrl = "Michael_JacksonPhotoUrl.jpg", ArtistGenres = new List<Genre> { pop, rnb, soul, disco } };
            Artist aa8 = new Artist { Name = "Future", Country = Country.USA, CareerStartDate = new DateTime(2005, 1, 1), PhotoUrl = "FuturePhotoUrl.jpg", ArtistGenres = new List<Genre> { hipHop, trap } };
            Artist aa9 = new Artist { Name = "Eminem", Country = Country.USA, CareerStartDate = new DateTime(1988, 1, 1), PhotoUrl = "EminemPhotoUrl.jpg", ArtistGenres = new List<Genre> { hipHop } };
            Artist aa10 = new Artist { Name = "Ice Cube", Country = Country.USA, CareerStartDate = new DateTime(1986, 1, 1), PhotoUrl = "Ice-CubePhotoUrl.jpg", ArtistGenres = new List<Genre> { hipHop } };
            Artist aa11 = new Artist { Name = "The Notorious B.I.G.", Country = Country.USA, CareerStartDate = new DateTime(1992, 1, 1), PhotoUrl = "The_Notorious_B.I.GPhotoUrl.jpg", ArtistGenres = new List<Genre> { hipHop } };


            #endregion

            #region Seeding Albums
            Album aam1 = new Album { Title = "Brown Sugar", ReleaseDate = new DateTime(1995, 6, 13), CoverPhotoUrl = "BrownSugarCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { rnb }, Artist = aa1 };
            Album aam2 = new Album { Title = "Sirens of the Sea", ReleaseDate = new DateTime(2008, 4, 21), CoverPhotoUrl = "DANGELOCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { trance, house }, Artist = aa2 };
            Album aam3 = new Album { Title = "Culture II", ReleaseDate = new DateTime(2018, 1, 26), CoverPhotoUrl = "Culture_IICoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { hipHop, trap }, Artist = aa3 };
            Album aam4 = new Album { Title = "No Label II", ReleaseDate = new DateTime(2014, 2, 25), CoverPhotoUrl = "Migos_No_Label_2CoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { hipHop, trap }, Artist = aa3 };
            Album aam5 = new Album { Title = "Unknown Album", ReleaseDate = new DateTime(1901, 1, 1), CoverPhotoUrl = "UnknownCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { traditional }, Artist = aa4 };
            Album aam6 = new Album { Title = "Cupid's Head", ReleaseDate = new DateTime(2013, 9, 30), CoverPhotoUrl = "Cupids_HeadCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { techno, electronic }, Artist = aa5 };
            Album aam7 = new Album { Title = "What's Going On", ReleaseDate = new DateTime(1971, 5, 21), CoverPhotoUrl = "WhatsGoingOnCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { soul }, Artist = aa6 };
            Album aam8 = new Album { Title = "Thriller ", ReleaseDate = new DateTime(1982, 11, 30), CoverPhotoUrl = "Michael_Jackson_-_ThrillerCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { rnb, pop, disco }, Artist = aa7 };
            Album aam9 = new Album { Title = "High Off Life ", ReleaseDate = new DateTime(2020, 5, 15), CoverPhotoUrl = "High_Off_LifeCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { hipHop }, Artist = aa8 };
            Album aam10 = new Album { Title = "The Eminem Show", ReleaseDate = new DateTime(2002, 5, 26), CoverPhotoUrl = "The_Eminem_ShowCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { hipHop }, Artist = aa9 };
            Album aam11 = new Album { Title = "The Predator", ReleaseDate = new DateTime(1992, 11, 17), CoverPhotoUrl = "The_Predator_CoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { hipHop }, Artist = aa10 };
            Album aam12 = new Album { Title = "Ready to Die", ReleaseDate = new DateTime(1994, 9, 13), CoverPhotoUrl = "Ready_To_DieCoverPhotoUrl.jpg", AlbumGenres = new List<Genre> { hipHop }, Artist = aa11 };

            aa1.Albums.Add(aam1);
            aa2.Albums.Add(aam2);
            aa3.Albums = new HashSet<Album> { aam3, aam4 };
            aa4.Albums.Add(aam5);
            aa5.Albums.Add(aam6);
            aa6.Albums.Add(aam7);
            aa7.Albums.Add(aam8);
            aa8.Albums.Add(aam9);
            aa9.Albums.Add(aam10);
            aa10.Albums.Add(aam11);
            aa11.Albums.Add(aam12);

            #endregion

            #region Seeding Tracks
            Track at1 = new Track { Title = "Brown Sugar", DurationSecs = 253, AudioUrl = "D_'Angelo_-_Brown_Sugar_(Official_Video)_(128kbps).mp3", Album = aam1, Popularity = 3 };
            Track at2 = new Track { Title = "Alright", DurationSecs = 308, AudioUrl = "D_'Angelo_-_Alright_(128kbps).mp3", Album = aam1, Popularity = 2 };
            Track at3 = new Track { Title = "Jonz in My Bonz", DurationSecs = 334, AudioUrl = "D_'Angelo_-_Jonz_In_My_Bonz_(128kbps).mp3", Album = aam1 };
            Track at4 = new Track { Title = "Me and Those Dreamin' Eyes of Mine", DurationSecs = 268, AudioUrl = "D_'Angelo_-_Me_And_Those_Dreamin_'_Eyes_Of_Mine_(Official_Video)_(128kbps).mp3", Album = aam1, Popularity = 4 };
            Track at5 = new Track { Title = "Shit, Damn, Motherfacker", DurationSecs = 308, AudioUrl = "D_'Angelo_-_Shit,_Damn,_Motherfucker_(128kbps).mp3", Album = aam1, Popularity = 5 };
            Track at6 = new Track { Title = "Smooth", DurationSecs = 251, AudioUrl = "D_'Angelo_-_Smooth_(128kbps).mp3", Album = aam1, Popularity = 2 };
            Track at7 = new Track { Title = "Cruisin", DurationSecs = 374, AudioUrl = "D_'Angelo_-_Cruisin_'_(128kbps).mp3", Album = aam1, Popularity = 1 };
            Track at8 = new Track { Title = "When We Get By", DurationSecs = 326, AudioUrl = "D_'Angelo_-_When_We_Get_By_(128kbps).mp3", Album = aam1 , Popularity = 2 };
            Track at9 = new Track { Title = "Lady", DurationSecs = 328, AudioUrl = "D_'Angelo_-_Lady_(128kbps).mp3", Album = aam1, Popularity = 3 };
            Track at10 = new Track { Title = "Higher", DurationSecs = 319, AudioUrl = "D_'Angelo_-_HIGHER_(128kbps).mp3", Album = aam1, Popularity = 4 };

            Track at11 = new Track { Title = "Just Listen", DurationSecs = 210, AudioUrl = "Above_feat_Beyond_presents_Oceanlab_-_Just_Listen_(128kbps).mp3", Album = aam2, Popularity = 4 };
            Track at12 = new Track { Title = "Sirens of the Sea", DurationSecs = 334, AudioUrl = "Above_&_Beyond_pres._Sirens_Of_The_Sea_-_OceanLab_(128kbps).mp3", Album = aam2, Popularity = 3 };
            Track at13 = new Track { Title = "If I Could Fly", DurationSecs = 305, AudioUrl = "Above_&_Beyond_pres._OceanLab_-_If_I_Could_Fly_(128kbps).mp3", Album = aam2, Popularity = 1 };
            Track at14 = new Track { Title = "Breaking Ties", DurationSecs = 308, AudioUrl = "Above_&_Beyond_pres._Oceanlab_-_Breaking_Ties_(128kbps).mp3", Album = aam2, Popularity = 3 };
            Track at15 = new Track { Title = "Miracle", DurationSecs = 386, AudioUrl = "Above_&_Beyond_pres._OceanLab_-_Miracle_(128kbps).mp3", Album = aam2, Popularity = 2 };
            Track at16 = new Track { Title = "Come Home", DurationSecs = 260, AudioUrl = "Above_&_Beyond_pres._OceanLab_-_Come_Home_(128kbps).mp3", Album = aam2, Popularity = 5 };
            Track at17 = new Track { Title = "On a Good Day", DurationSecs = 334, AudioUrl = "Above_&_Beyond_pres._Oceanlab-on_a_good_day_(128kbps).mp3", Album = aam2, Popularity = 3 };

            Track at18 = new Track { Title = "Higher We Go", DurationSecs = 249, AudioUrl = "Migos_-_Higher_We_Go_(Intro_Audio)_(128kbps).mp3", Album = aam3, Popularity = 3 };
            Track at19 = new Track { Title = "Supastars", DurationSecs = 272, AudioUrl = "Migos_-_Supastars_(Audio)_(128kbps).mp3", Album = aam3, Popularity = 2 };
            Track at20 = new Track { Title = "Narcos", DurationSecs = 249, AudioUrl = "Migos_-_Narcos_(Audio)_(128kbps).mp3", Album = aam3, Popularity = 3 };
            Track at21 = new Track { Title = "BBO (Bad Bitches Only)", DurationSecs = 247, AudioUrl = "Migos_-_BBO_(Bad_Bitches_Only)__ft._21_Savage_(Audio)_(128kbps).mp3", Album = aam3, Popularity = 2 };
            Track at22 = new Track { Title = "Auto Pilot", DurationSecs = 268, AudioUrl = "Migos_-_Auto_Pilot_(Audio)_(128kbps).mp3", Album = aam3, Popularity = 3 };
            Track at23 = new Track { Title = "Walk It Talk It", DurationSecs = 262, AudioUrl = "Migos_-_Walk_It_Talk_It_ft._Drake_(Audio)_(128kbps).mp3", Album = aam3, Popularity = 3 };
            Track at24 = new Track { Title = "Emoji a Chain", DurationSecs = 309, AudioUrl = "Migos_-_Emoji_A_Chain_(Audio)_(128kbps).mp3", Album = aam3, Popularity = 3 };
            Track at25 = new Track { Title = "CC", DurationSecs = 251, AudioUrl = "Migos_-_CC__ft._Gucci_Mane_(Audio)_(128kbps).mp3", Album = aam3, Popularity = 4 };
            Track at26 = new Track { Title = "White Sand", DurationSecs = 193, AudioUrl = "Migos_-_White_Sand_ft._Travis_Scott,_Ty_Dolla_$ign,_Big_Sean__(Audio)_(128kbps).mp3", Album = aam3, Popularity = 2 };

            Track at27 = new Track { Title = "Intro No Label 2", DurationSecs = 246, AudioUrl = "Migos_-_No_Label_2___Intro___(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 3 };
            Track at28 = new Track { Title = "Copy Me", DurationSecs = 264, AudioUrl = "Migos_-_Copy_Me_(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 3 };
            Track at29 = new Track { Title = "Contraband", DurationSecs = 188, AudioUrl = "Migos_-_Contraband_(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 2 };
            Track at30 = new Track { Title = "Add It Up", DurationSecs = 244, AudioUrl = "Migos_-_Add_It_Up_(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 4 };
            Track at31 = new Track { Title = "Peek a Boo", DurationSecs = 254, AudioUrl = "Migos_-_Peek_A_Boo_(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 4 };
            Track at32 = new Track { Title = "Antidote", DurationSecs = 205, AudioUrl = "Migos_-_Antidope_(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 3 };
            Track at33 = new Track { Title = "Migo Dreams", DurationSecs = 147, AudioUrl = "Migos_-_Migo_Dreams_ft._Meek_Mill_(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 4 };
            Track at34 = new Track { Title = "Kidding Me", DurationSecs = 199, AudioUrl = "Migos_-_Kidding_Me_(No_Label_2)_(128kbps).mp3", Album = aam4, Popularity = 5 };

            Track at35 = new Track { Title = "Ancient Greek Music", DurationSecs = 1800, AudioUrl = "Ancient_Greek_Music_(64kbps).mp3", Album = aam5, Popularity = 3 };
            Track at36 = new Track { Title = "Chinese Instrumental Music", DurationSecs = 3720, AudioUrl = "Chinese_Musical_Instruments_-_Relaxing_Music.mp3", Album = aam5, Popularity = 3 };
            Track at37 = new Track { Title = "Epic Nordic-Viking Music", DurationSecs = 3780, AudioUrl = "VIKINGS_Most_Epic_Viking_&_Nordic_Folk_Music_Danheim.mp3", Album = aam5, Popularity = 4 };

            Track at38 = new Track { Title = "They Won't See Me", DurationSecs = 515, AudioUrl = "The Field - They Won_'t See Me (128kbps).mp3", Album = aam6, Popularity = 3 };
            Track at39 = new Track { Title = "Black Sea", DurationSecs = 681, AudioUrl = "The Field - Black Sea (128kbps).mp3", Album = aam6, Popularity = 3 };
            Track at40 = new Track { Title = "Cupid's Head", DurationSecs = 379, AudioUrl = "The Field - Cupid_'s Head _'Cupid_'s Head_' Album (128kbps).mp3", Album = aam6, Popularity = 4 };
            Track at41 = new Track { Title = "A Guided Tour", DurationSecs = 488, AudioUrl = "A Guided Tour (128kbps).mp3", Album = aam6, Popularity = 4 };
            Track at42 = new Track { Title = "No. No...", DurationSecs = 540, AudioUrl = "No. No… (128kbps).mp3", Album = aam6, Popularity = 3 };
            Track at43 = new Track { Title = "20 Seconds of Affection", DurationSecs = 563, AudioUrl = "20 Seconds Of Affection (128kbps).mp3", Album = aam6, Popularity = 3 };

            Track at44 = new Track { Title = "What's Going On", DurationSecs = 211, AudioUrl = "Marvin_Gaye_-_What_'s_Going_On_(128kbps).mp3", Album = aam7, Popularity = 3 };
            Track at45 = new Track { Title = "What's Happening Brother", DurationSecs = 154, AudioUrl = "Marvin_Gaye_-_What_'s_Happening_Brother_(128kbps).mp3", Album = aam7, Popularity = 3 };
            Track at46 = new Track { Title = "Flyin' High (In the Friendly Sky)", DurationSecs = 204, AudioUrl = "Flyin_'_High_(In_The_Friendly_Sky)_(128kbps).mp3", Album = aam7, Popularity = 5 };
            Track at47 = new Track { Title = "Save the Children", DurationSecs = 182, AudioUrl = "Marvin_Gaye_-_Save_the_Children_(128kbps).mp3", Album = aam7, Popularity = 4 };
            Track at48 = new Track { Title = "God Is Love", DurationSecs = 86, AudioUrl = "God_Is_Love_(128kbps).mp3", Album = aam7, Popularity = 3 };
            Track at49 = new Track { Title = "Mercy Mercy Me (The Ecology)", DurationSecs = 183, AudioUrl = "Marvin_Gaye_-_Mercy_Mercy_Me_(The_Ecology)_[playlist-friendly]_(128kbps).mp3", Album = aam7, Popularity = 3 };

            Track at50 = new Track { Title = "Wanna Be Startin' Somethin'", DurationSecs = 362, AudioUrl = "Michael Jackson - Wanna Be Startin_' Somethin_' (Audio) (128kbps).mp3", Album = aam8, Popularity = 4 };
            Track at51 = new Track { Title = "Baby Be Mine", DurationSecs = 253, AudioUrl = "Michael Jackson - Baby Be Mine (Audio) (128kbps).mp3", Album = aam8, Popularity = 3 };
            Track at52 = new Track { Title = "The Girl Is Mine", DurationSecs = 205, AudioUrl = "Michael Jackson - The Girl Is Mine ft. Paul McCartney (128kbps).mp3", Album = aam8, Popularity = 3 };
            Track at53 = new Track { Title = "Thriller", DurationSecs = 335, AudioUrl = "Michael Jackson - Thriller - Thriller (128kbps).mp3", Album = aam8, Popularity = 3 };

            Track at54 = new Track { Title = "Trapped in the Sun", DurationSecs = 193, AudioUrl = "Future_-_Trapped_In_The_Sun_(Audio)_(128kbps).mp3", Album = aam9, Popularity = 3 };
            Track at55 = new Track { Title = "HiTek Tek", DurationSecs = 181, AudioUrl = "Future_-_HiTek_Tek_(Audio)_(128kbps).mp3", Album = aam9, Popularity = 3 };
            Track at56 = new Track { Title = "Touch the Sky", DurationSecs = 134, AudioUrl = "Future_-_Touch_The_Sky_(Audio)_(128kbps).mp3", Album = aam9, Popularity = 2 };
            Track at57 = new Track { Title = "Solitaires", DurationSecs = 195, AudioUrl = "Future_-_Solitaires_(Audio)_ft._Travis_Scott_(128kbps).mp3", Album = aam9, Popularity = 4 };
            Track at58 = new Track { Title = "Ridin Strikers", DurationSecs = 207, AudioUrl = "Future_-_Ridin_Strikers_(Audio)_(128kbps).mp3", Album = aam9, Popularity = 4 };
            Track at59 = new Track { Title = "One of My", DurationSecs = 133, AudioUrl = "Future_-_One_Of_My_(Audio)_(128kbps).mp3", Album = aam9, Popularity = 4 };
            Track at60 = new Track { Title = "Posted with Demons", DurationSecs = 185, AudioUrl = "Future_-_Posted_With_Demons_(Audio)_(128kbps).mp3", Album = aam9, Popularity = 3 };
            Track at61 = new Track { Title = "Hard to Choose One", DurationSecs = 188, AudioUrl = "Future_-_Hard_To_Choose_One_(Audio)_(128kbps).mp3", Album = aam9, Popularity = 3 };
            Track at62 = new Track { Title = "Trillionaire", DurationSecs = 148, AudioUrl = "Future_-_Trillionaire_(Audio)_ft._Youngboy_Never_Broke_Again_(128kbps).mp3", Album = aam9, Popularity = 4 };
            Track at63 = new Track { Title = "Harlem Shake", DurationSecs = 137, AudioUrl = "Future_-_Harlem_Shake_(Audio)_ft._Young_Thug_(128kbps).mp3", Album = aam9, Popularity = 5 };

            Track at64 = new Track { Title = "White America", DurationSecs = 332, AudioUrl = "White_America_(128kbps).mp3", Album = aam10, Popularity = 3 };
            Track at65 = new Track { Title = "Business", DurationSecs = 247, AudioUrl = "Business_(128kbps).mp3", Album = aam10, Popularity = 4 };
            Track at66 = new Track { Title = "Cleanin' Out My Closet", DurationSecs = 274, AudioUrl = "Cleanin_'_Out_My_Closet_(128kbps).mp3", Album = aam10, Popularity = 2 };
            Track at67 = new Track { Title = "Square Dance", DurationSecs = 314, AudioUrl = "Square_Dance_(128kbps).mp3", Album = aam10, Popularity = 5 };
            Track at68 = new Track { Title = "Soldier", DurationSecs = 208, AudioUrl = "Soldier_(128kbps).mp3", Album = aam10, Popularity = 3 };
            Track at69 = new Track { Title = "Say Goodbye Hollywood", DurationSecs = 259, AudioUrl = "Say_Goodbye_Hollywood_(128kbps).mp3", Album = aam10, Popularity = 3 };
            Track at70 = new Track { Title = "Drips", DurationSecs = 267, AudioUrl = "Drips_(128kbps).mp3", Album = aam10, Popularity = 3 };
            Track at71 = new Track { Title = "Without Me", DurationSecs = 270, AudioUrl = "Without_Me_(128kbps).mp3", Album = aam10, Popularity = 4 };
            Track at72 = new Track { Title = "Sing for the Moment", DurationSecs = 323, AudioUrl = "Sing_For_The_Moment_(128kbps).mp3", Album = aam10, Popularity = 5};
            Track at73 = new Track { Title = "Superman", DurationSecs = 330, AudioUrl = "Superman_(128kbps).mp3", Album = aam10, Popularity = 2 };
            Track at74 = new Track { Title = "Hailie's Song", DurationSecs = 312, AudioUrl = "Hailie_'s_Song_(128kbps).mp3", Album = aam10, Popularity = 1 };
            Track at75 = new Track { Title = "When the Music Stops", DurationSecs = 257, AudioUrl = "When_The_Music_Stops_(128kbps).mp3", Album = aam10, Popularity = 2 };
            Track at76 = new Track { Title = "Say What You Say", DurationSecs = 305, AudioUrl = "Say_What_You_Say_(128kbps).mp3", Album = aam10, Popularity = 2 };
            Track at77 = new Track { Title = "Till I Collapse", DurationSecs = 274, AudioUrl = "Till_I_Collapse_(128kbps).mp3", Album = aam10, Popularity = 5 };
            Track at78 = new Track { Title = "My Dad's Gone Crazy", DurationSecs = 256, AudioUrl = "My_Dad_'s_Gone_Crazy_(128kbps).mp3", Album = aam10, Popularity = 3 };

            Track at79 = new Track { Title = "When Will They Shoot", DurationSecs = 262, AudioUrl = "Ice_Cube__-_When_Will_They_Shoot_(128kbps).mp3", Album = aam11, Popularity = 3 };
            Track at80 = new Track { Title = "Wicked", DurationSecs = 213, AudioUrl = "Ice_Cube__-Wicked_(128kbps).mp3", Album = aam11, Popularity = 3 };
            Track at81 = new Track { Title = "Now I Gotta Wet 'Cha", DurationSecs = 242, AudioUrl = "Ice_Cube__-Now_I_Gotta_Wet_Cha_(128kbps).mp3", Album = aam11, Popularity = 3 };
            Track at82 = new Track { Title = "The Predator", DurationSecs = 242, AudioUrl = "Ice_Cube__-The_Predator_(128kbps).mp3", Album = aam11, Popularity = 5 };
            Track at83 = new Track { Title = "It Was a Good Day", DurationSecs = 251, AudioUrl = "Ice_Cube__-_It_Was_A_Good_Day_(128kbps).mp3", Album = aam1, Popularity = 5 };
            Track at84 = new Track { Title = "We Had to Tear This Mothafucka Up", DurationSecs = 254, AudioUrl = "Ice_Cube__-_We_Had_to_Tear_This_Mothafucka_Up_(128kbps).mp3", Album = aam11, Popularity = 2 };
            Track at85 = new Track { Title = "Dirty Mack", DurationSecs = 260, AudioUrl = "Ice_Cube__-__Dirty_Mack_(128kbps).mp3", Album = aam11, Popularity = 3 };
            Track at86 = new Track { Title = "Don't Trust 'Em", DurationSecs = 244, AudioUrl = "Ice_Cube__-__Don_'t_Trust__'Em_(128kbps).mp3", Album = aam11, Popularity = 2 };
            Track at87 = new Track { Title = "Gangsta's Fairytale 2", DurationSecs = 191, AudioUrl = "Ice_Cube__-__Gangsta_'s_Fairytale_2_(128kbps).mp3", Album = aam11, Popularity = 1};

            Track at88 = new Track { Title = "Things Done Changed", DurationSecs = 215, AudioUrl = "The_Notorious_B.I.G._-_Things_Done_Changed_(128kbps).mp3", Album = aam12, Popularity = 3 };
            Track at89 = new Track { Title = "Gimme the Loot", DurationSecs = 302, AudioUrl = "The_Notorious_B.I.G._-_Gimme_the_Loot_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 3 };
            Track at90 = new Track { Title = "Machine Gun Funk", DurationSecs = 250, AudioUrl = "The_Notorious_B.I.G._-_Machine_Gun_Funk_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 3 };
            Track at91 = new Track { Title = "Ready to Die", DurationSecs = 254, AudioUrl = "The_Notorious_B.I.G._-_Ready_to_Die_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 4 };
            Track at92 = new Track { Title = "Juicy", DurationSecs = 301, AudioUrl = "The_Notorious_B.I.G.-Juicy_(128kbps).mp3", Album = aam12, Popularity = 4 };
            Track at93 = new Track { Title = "Everyday Struggle", DurationSecs = 311, AudioUrl = "The_Notorious_B.I.G._-_Everyday_Struggle_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 3 };
            Track at94 = new Track { Title = "Me & My Bitch", DurationSecs = 240, AudioUrl = "The_Notorious_B.I.G._-_Me_&_My_Bitch_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 1};
            Track at95 = new Track { Title = "Big Poppa", DurationSecs = 248, AudioUrl = "The_Notorious_B.I.G._-_Big_Poppa_(128kbps).mp3", Album = aam12, Popularity = 5 };
            Track at96 = new Track { Title = "Respect", DurationSecs = 313, AudioUrl = "The_Notorious_B.I.G._-_Respect_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 2 };
            Track at97 = new Track { Title = "Friend of Mine", DurationSecs = 197, AudioUrl = "The_Notorious_B.I.G._-_Friend_of_Mine_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 3 };
            Track at98 = new Track { Title = "Unbelievable", DurationSecs = 206, AudioUrl = "The_Notorious_B.I.G._-_Unbelievable_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 3 };
            Track at99 = new Track { Title = "Suicidal Thoughts", DurationSecs = 150, AudioUrl = "The_Notorious_B.I.G._-_Suicidal_Thoughts_(Official_Audio)_(128kbps).mp3", Album = aam12, Popularity = 3 };


            aam1.Tracks = new HashSet<Track> { at1, at2, at3, at4, at5, at6, at7, at8, at9, at10 };
            aam2.Tracks = new HashSet<Track> { at11, at12, at13, at14, at15, at16, at17 };
            aam3.Tracks = new HashSet<Track> { at18, at19, at20, at21, at22, at23, at24, at25, at26 };
            aam4.Tracks = new HashSet<Track> { at27, at28, at29, at30, at31, at32, at33, at34 };
            aam5.Tracks = new HashSet<Track> { at35, at36, at37 };
            aam6.Tracks = new HashSet<Track> { at38, at39, at40, at41, at42, at43 };
            aam7.Tracks = new HashSet<Track> { at44, at45, at46, at47, at48, at49 };
            aam8.Tracks = new HashSet<Track> { at50, at51, at52, at53 };
            aam9.Tracks = new HashSet<Track> { at54, at55, at56, at57, at58, at59, at60, at61, at62, at63 };
            aam10.Tracks = new HashSet<Track> { at64, at65, at66, at67, at68, at69, at70, at71, at72, at73, at74, at75, at76, at77, at78 };
            aam11.Tracks = new HashSet<Track> { at79, at80, at81, at82, at83, at84, at85 };
            aam12.Tracks = new HashSet<Track> { at88, at89, at90, at91, at92, at93, at94, at95, at96, at97, at98, at99 };


            #endregion



            #endregion


            return new List<Artist> { aa1, aa2, aa3, aa4, aa5, aa6, aa7, aa8, aa9, aa10, aa11 };
        }
    }
}
