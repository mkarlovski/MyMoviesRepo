﻿using MyMovies.Models;
using MyMovies.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repository
{
    public class MovieRepository :IMovieRepository
    {
        public List<Movie> Movies { get; set; }

        public MovieRepository()
        {
            Movies = new List<Movie>();
            var movie = new Movie()
            {
                ID = 1,
                Title = "Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ImageURL = "https://images-na.ssl-images-amazon.com/images/I/51zUbui%2BgbL._SY445_.jpg",
                //Cast = new List<string>
                //{
                //    "Tim Robins",
                //    "Morgan Freeman",
                //    "Bob Gunton"
                //}
                Cast = "Tim Robins,Morgan Freeman"
            };
            var movie2 = new Movie()
            {
                ID = 2,
                Title = "Money Heist",
                Description = "An unusual group of robbers attempt to carry out the most perfect robbery in Spanish history - stealing 2.4 billion euros from the Royal Mint of Spain.",
                ImageURL = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMTEhUTExMWFRUXFxoYGBgXFxcaFxoZGBcaGh8YGB8dHSggGhonGxoYITEiJSkrLi4uGCAzODMtNygtLysBCgoKDg0OGxAQGy0lICYvLS8tLS8tLS0tNS0tLy8tLS0tLS8vLS0tLy0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLf/AABEIAREAuAMBIgACEQEDEQH/xAAcAAACAgMBAQAAAAAAAAAAAAAEBQMGAAECBwj/xABEEAABAwIEAwYFAQYEBQIHAAABAgMRACEEBRIxQVFhBhMicYGRMqGxwfDRBxQjUuHxM0JysggVgpKzk+IWU2JzwsPF/8QAGgEAAwEBAQEAAAAAAAAAAAAAAQIDBAAFBv/EAC8RAAEEAQMDAgYBBAMAAAAAAAEAAgMRIQQSMSJBURNhMnGBkaHw0RQjseEFwfH/2gAMAwEAAhEDEQA/APOcgzdTShptqsT9+U8K4y9goU4jV4UkRPMifeKEwb4TBBkcQRHvU/fhSioWJMwNhyHtas7l7Gmj2vBtTYh5KgAbCfEeJk7A8OfpSPHtFKynfiPWmWJckEcvERxseHpNK8aqVFRsTBAg7aRB9RFMwJdY8H7/AIUBqVlQm9aOm0ki39q1pinWNpp2FdMnw0onnQ+cZdKVEDxRb9DRvZrCa9LetYkGIVFwNR2Nhvvy9a47RNLwpQtS9SVGFJN1AgCdJgE7/wBOJz7SHYXr/wBXE5mxwNKqEFCIsCbGJmOvLhaKGirt3DJEqQgnnAuOftVRzRgIWQNjcQZEf3qjHbismp07oWgk32Tfs9lDTyIWVpVwIiN7cOVK8bhlNOFtYgjjwPIjoaadnnilAMGAozA3G9vWf+2jO1aEuoS6i8XBHLiOn/tNC+rKsGMdACzkDP8A2qyqictxRaVtKZmJjrQiVbeY+td0/ZZaDnX+90xxmOU6pbiolRJtwvYelBpUdYSBJmAAdzUTcFQBMCdz9qdIwzSShxhWpaTcKMp2nhx/IoYCo9znMJGAPv8ARa/5fiBqUGXTp3KQdMG28RSV5HGIuQbRfnHvXreGzlwQ0cOtCnEJVIhTY1AG95gGxtaK8wzfBOohTn+YlQF7JJi/W077RXNd5WT0s23PlAtLhQMT+frFRKo1sp7pSR8aimOQj+/zoNSSCZ3pgnfjAXNcgVK00pZ0pBJrMThlo+JJTO0i3pTKRB5rHlcJrK4F63XJQT2RxVBsZBv0rttUW9v0P6/hDdVsee9dIVY9IpKWv1M45TbCEFYPO00PhwXlkrJg2BN4iYBv9K4DxSArnf1B/PeustTDqo5ki3OuGLTyFshZfF5Vraw2pBbUhISeKdhbeDB+vnVMxzSkrUlW4MH85VecvxKtHibW3B0ytJCSYmx9RSTP8IXVAoTK7gi1wPuKk00aK3Txtli3Rm6UXZrMVIdbgpKkqtqJEiI+9H9tcX3qkNhQcWASopjSJAhIuY4kyePpVbdwS0DxtqEcSLfpXSFlMkHflTnmwsDI89XC7ViFhKQTMJ025Db2ED0oJ90qieHLqa7W5EjmIO/uPatNIUqREkCfQcaYYyg5xf09lY+zWIMtgN6gFJkDTcDcX4mmmNy/SpbRTpBUSEkyYWB87n2pBlwU1pWFQRe31pngcc6uXHFFar+I8hYcLCAKk7ytGiYRLTvBQWL7KLSJbWHDyjSfS8b8KrzySgwbXIg8COBq6pxi58Jvy51Xc0dC/GoXKgT1IifcWp2OJwUNbpmxjfHjyEp1SaPw7w7xKSdKDtMwJ3mPW+8RS4b1KhVUKwAlwpelv50FNFCXAYSRKVEgkiwlV1E/Sqz2nx61gKUPDBjqudN7Da1LMIRNzpO0TA9KbuBCZKwVANkFMzfUCL/9NQoBy9WOM+g6jlV1SNLSQfiJn0H4KHYZUtWkXJ/JovHGGxO526VLkmGUZcAg3AJsnz61oOMrxowXDa0ZW8PiNHggApVuOJFpNOQEuIKVAQeQi/MdZqsLWZJnczTLAYsyEgFSjsBM38qi5t8L1IJ2sbUnCX47Bd2qD6dRzrKdOtkpCnhYrKAlSdKgAknVIO022HOsp99YKyf0nqkuiIA9+UgW2dIPD9a7YiCOdTJbGtKCoBuRPAkcuFR41ru3FJG3C82ImD1Ex6UfZI1wvcOFLh3EhMwJ5kX9OlZgXCXSoGPwfnrQaDWTBkVwCMjy5gHheo5Zii40EknSVaXZkxbYkA2NvEOEm24RYhPcvlBM6Os2OxJ3NiJorsjnCRh3QTEKCiTZIEAEzBkwNqreZY5CjqQblWxBkCIE84EVIt7LVpJNhLr7K1/vqVJMgbbb/wBxVIzBCUPREpkKiTEHhzrk41aT4SRNx7/gqPHuanCRtb6frNFjKKpqtU2VgrkFPcyyBOgPYeSmNRbNyBzSeIjhvSNpQmY8rxE8bdKv3Z3Lne4SdQ7wAKCFJIhJUU3VI20km3lMiaTnBh5SggokkKR/KsfEkdJIPrXAnhI90WHM+oReHxx06J8JiZANwSLWkXnY7USziCAUhR0xEGD9p+dJ2XB8/qP1miioyLwOJG9cQtOnk6L5KmzB6E2gGQARvJk/QfMc6zG4HW2okxCgQecmJNCY1MRymx+v29utdZhjYRoCtU7ySYjn+cKIBxSlNIC2T1P3x+UrabkxPrw86vORdhTiGkuNrTf/AOZIPAahAIHG0HzqkMDcdY/PWvTexLjjamyCVAqDa0k2M6gFC5uIE2T8SfiixeT2XnNADPmq92v7MKwJTcLT/NFjMCY4GbEX3B4wAU5kO7i+244Ry5+VXTt9g9WHWsg6gSFEkSTGoHe4GkJG3KIivL0HYe/rSgbuVtj1DmNx3H54/wAJmQgrSpZBHBMcOd7eh51PjMwGjSnypUtRO964KqPPK5jhE3a1Rk86JwWK0kf5Vc9p5XqDVWDhzp1kcLPKNzHEkwSqbekk3+UVlaZwLiwTEJBk8zE3A3O5rKWwrNikI6cBWTB4Bt1uFpSRsLQR5Hgaq+aZephUbpV8KvseRq25Q4stWbnSJV4o6zt+RUOOSl4qYcBbWLwRMQdxe/HlvSNJac8LXM2GZlRnr7dvoqYtMe01y2ZEVbswyBbWHWnvEuJnUkFMEQD8Jk8OGxiqi9arAg8Ly5WvicBIKUjY/PKtxUTbn5+eldumwg11FASsAWnABBn0+/5yqdCgDJHEW51y0saDxUYjpveicAxrBBupJnzSf0P1oOwnhDpHUF6B2IxjpfSUBJCkKbhRtFjwmwgbxtQWOy1CsTi0LhWh+xFoJQAQL+kGdryaiyFkNw9qOgBWrhpPP2oDL9SEuLNg4qQDvxufOflUCfC3aSIiXqHHK47QZa2Ed4j4hAV1G0nr1pPhHxJm44ij84dgESLwYnkePypGy6QrV1p2NJaunnbHPQFDumv7uFpJiUDSCCSNyb2240anIWQSpRkHYJV4U9J3Jjy41JkuE/egoFfdhI1BI0lJ4EmdzSrHPuoJbUbz5fSjTkGy6V7rIvxjCizBLYVDQgAbyTJnrVj7O5o4hbRCO8E6tJUlIO5Fzab1U96aZJjXmVpUyuD/ANJ6kXvwrjwoyN3OFD7K69qMUp0obXKNYlQkW3AI9zvyqpYvswUAlC9UCYIEnyiiMZiFqXrdOpR32iLiBFh+daHdzUptJPKpi+y3iKNsYDxkKvrNqhFG4lOo+AWN1E8Dx867yvLFOk7QDedv61a6GV5rml79rcoJAJNh+fgonBIBUJE8hTXM8AW2yUqBSLKAEb7fPyoHJinXfhHKN78DQBsJnsMLurlWRTS0NhZSNBsSFfCZiCCBF7dDWU2xaSGbqsQuNQFgUqAMyIi3pIjllT2gq8eue0U7KV9jM2AcEgkFCkhITN5BA5cNzzoTthiyMYhQuW0p8E7XUdFuOkgevGq9g8QptWpCyk9DFFtOqGrVdSzJUZKjccZ605GVGGMk2ce6aYjOztwn5bfSq0+yA6REgK26cvaiMS9qgcRx9v0+dCYonUb3H9ppoxSGvl9QD2R7GGlY0WHLhe+n/wCodKIzLLAVJCP80COEnl0mucjaLi0pJAvYkkX5edej4bs6julqcSA4wSrUJEkJO8m/A7D4eO5L30VjhiLjleV4ZBQfEkjzBH1o3UkLBAAsY025X8v61asXiEaykpBEA34zvSvOsnQG++Z4fEnhHNPKOVS3Wvb/AKcxNoZAQTeYq0lJJ0zcTYkEiSPnUbrogjrS4uXPmPmI+1TNgEKUSJAsk8QZB9aYtCiJnEUOcpjgct7xBWs6U7AgSogGZ96UZmyjvAloEJ2uZJIuSeW4t0pk08EJ/wARSyRZMq0joRNLmHD3gmDKib9dx+cqZpys+qjaIxjPcr0Lsj2fJQhUgJnaOPO9jNJ+1fZ89/oQsFWkEyCASSRbfgmnHZUoUtbSHHEp7oKSAqDrC0yUjiYkdah7R5glKj3aFKLekSpRJVxUCTJ3UfKKkXEFHT6drzxgZVIxWVPN3UgwNyLjY+sUPrBAHCrjjM2TpjVHpNutUzMAAs6bDly5j3Bp2m1WaMQ5HdFKxVt7cqjwuHcfUUoAjmdhBoAGn+BzINNBKUiYmes8aY9Iwpxyeu6nGmhdqyEpEqfCbXAST9xRmSNaU2+e3n0pBjscpe+0zx/Wj8EtfdgNqhQIsdjvY/rSFpIyrCeGJ9taf35p1mSQUKHEiLdedU1oKaV/ESoTbb5jnVixmKW0Ehags8VDfrbh52rrGlD7UAgK3HQjh9vWg0lvKadrNUNzDRHZLsVmiVJDbZcKLaismwH+VIkxWUpJrKrS89kgYKK6B39/t+lSoX18qG68Nq1Jo0l9XbhTtrM3HmZrjupkiowqjWhauJpNG0SGipcHjwELQqxIgxxG/wBa9Md7VKdwQ1BJUUpbMKk38JWRwJ+/rXmyMCD4lJMRMbSOJ8hvb70RhYnaOkwAZ4fMVN9ELRp9O8SAGv8ASaY86VydtI+oFZgcXBKepPzn9aGwWHDjjbZMaoST8526GhcK9bVYatzN/bcUlL1zNclIJbADix/lCvceIge1RqVepsyR4wRbw/T+9CFVUonK8hxbG5zBzamSqonU8Rwk+1/tXDLk2pg1HhI32I6yYPkdqPBXNAmbVo/LM7Q2AENhbxt3hslE8YI8RG/AVIjFHTe4O5kyTzPO4pTgsONaiLDh0G5ny29KIcfEWkJjfirjInhtHDzNqVwBOFXTP9FnWcnt7BD4x6CR/bc70uxrsrJrvFETMUOkSao1q8/UahzzSnw6bTXQVR2Ayhxw6Ux/qVITPLzrvMMkdbTqMEc0mfWg4i6XQk7SlqzajctcEEFQSQDvxG/r6D60vB+o+tdA13ZMeo2p1OlUmbDhzB4k8TWMPkHeh5rpC4vxn2rqtO123hdt4F1QJCCRxHH0G9ZVmydrw6vY/WsqRlNrdH/xrS0HcfwtZjliFtKIT4wJB4kjnzPCTVRKq9LewIQ0ClalEAagoCw2mRA9PM1W3MjaUCRIJJ2PX2iix+3BUtRpxqafDXuOFV0CjcIQVAK/PKx9jU7+UqRcEEX6GhEqUm4jqCJFVsOGFgYHQPAeKVjwSxqSl/UEX/iNgHSeBUn+XeR8+Uub5K7hxqKdSIOlaDKFpAkEHmE2IMHw9RQGHxpW0dAhSYmOA5j6VodrMQWv3dOgtE/CtCVet9vSphpK9HUagRuDwbxj9+yN7IYtAcUtxRCkjwpAmQZ4zaPvQeJwC2hchQNyLWnkd6IwWTLBQ42SYMG0CY2B2mL3NT51l+I7sKgKTMm/jA9LER1Nc7DsI6PqhL3A7s5VafdSCAfW/wCRWLw+qVJ+ERPrRfaHL0tuDSRcDUOSoG3Q/ahnMWoNhqbAzbqZj3qgOBSwSsqV3qdvH4UmHyhS1QggEgqSDNwN9h9a4DRBTO0gGOEmDPvV67PdmnVspeSpClpQsBuSJ1C1+dtrC+9I8uf8RQpMkgoIIvIOyhwUDPWanvQYC3HlIVuW07D6+fOtl5OkiCTaSTy2gR5Uw7RZYGikp2KfEDuDJv5ERS3A4JapWBARuTsDwtvTDItO6UA0ULiEwYrMMyVKA6j61JiWVJjUNx4SLgjnPnRGDcCW1W8QO/ECPp+caezSy7QXE9lcMnM+DxISk+hmNiOMSZJ407xiNaSP8pSbnaZFo8r8jI6Slyx8FMkqQqAARKfEkGLgjcBQHD2s4WwCi8pUUWmQI4TtMDjbh51ldytTW3VLzDHtBDi0pMgKMczQ6pBANjR+YyHFXnxHaePETf3oFXiN60jhSeC11KZloq+ETzPD1rTjfj0g8YolOJOnSOQE8bfnzoVSb/m9KDlaHNGzCuWT4FakKCFnwAGIBEGbX2+H51qo+zOaBCHCXG0i06h4vCDYDULyeRrKQjPCVs8gGHH7p4jGIRhQ4V6lFtSSkqkEE2keYTB8xxqou44pPhNuXX8FAuZq4UpQVeEGYAAvz86GXibyed43o7FWKYRtOcpo5mGpPLh5elLnDFQ4d0zf/N0+laeclRI24U7W0oamb1WgnlcNqMkAxvPoa4w6ZUANyY61wmSTPGi8M+UJIgG833ChxBp+FkcbAvhew9nMY0vDJwjaYCiBKxAVsVBCv54uPlwqqdpni0opBu2vQDzhQE77EDbrWdnG8TiWk6EAobcSqRZRUnlFzHpTftJ2eU62rELSUQVOOIWpJVpAPit8JO5SZ33rKcFevpZvTY73GPmvPn1he4GocR859IoHEogzy/qakRiAFqAEAmw5Vw6oqUIvNXF2sMzmOZuHJOV6L2MLTv8ACU4vToSpMrIAWFSU7xBBAjYwLUo7QFJzF5LWkKKkpCdwVaEztx1bnnJpLluMdwelxESRI1AEQeUzB60KjMFF1TmyrmeN+v5vShluQlcWtFjKZ9pcE40WwspUpwnSRJiIHEDmPam2T9i8W4lJBQGYJMkySDMERvYXtVZGMU66gLJsbcYnc3O9emdnMZiylYbxCUoQpKfE1rPiBPAiwgC43V60X9IoKcf9zLlQ8zaBbDYBBa1A9CB9J+tV+Le9epdqey63it1EF4gJNtCFJEk7buHUg8htxrzN1lTSi26gpUDxHi/Qii3ItMKHSrz2E7RNhtSHlNgQCVKjX4OATfUL7ATJ3orGdpA6dIa0nURMaiUDYEiwPS4Brz9poDxJI+n9aZNYtAKdAWDxBIg1J7Ra3aZoFFxRHaVgQHJJUJmdJPQWtvw5Gq622eU07zjFBSY8j97fnGo8KQQgpjcA8T5UWmmppog+ewUDhWCVhKpAtPO9MM3y9DYSUEmbcCLb351Y8jwOGWtReAs4U+JQG22lX24RQvbPLcO2pHdurJJshRm089zc286YOBNLFIXCy04VUQmeIFZWpEnzrK5amltcBCpJrtllSzCRJ/WuSKKwDhTcb6gfICqFeazJycK45N+zh91F8QhCiNgkq9JkR6VWe0XZjEYJeh1HhN0rTJQR58PIxXqfYvOgpIM3B229qb9t1oXhwqPEFCPM2I8o+1QErhytbNO2RwbfPdfPjW9OcPgVODwiYvROMygLWVIGgj4kkW8xHD5UOl9xpRTsuLA/Crp6j6U5dfC0w6f0bEox7J1gMYlgp/hpcA4KSJF4IEzBrrM8wdeSUlXdpJuhFxpAvqsOPpVbGZ+GACL9DAO8Hfn71NgHVLSGwFKJMEc/ITJNAM7lS1GpYSBGOyAx+DW2oyLc+FDsri/KK9KzXsuoMBcJLiGu9cTpBSkFRASiZuEgz6XqjPYZJ4QelMJAVEaVzm7ghUYsn4iTCTEz7dBULbl551ytMGK5NVACyPc44cjmGipaQN4P+0mauPZNtxQWplLoc0gBYjuwTE96tRjRxgeI2AFV/sxiEpcU4vZDS1RzITsOtOuyGYpYYfxGkd6pelPVR8Wn/SPi9D0oFtpWOLVd82zoNFthJK+5Se8WRBW45BUY4AQkRw24UrzvLG8Wi4hQ2UNwfuOlUxeKKtZJkmSSdyZknzmm2T54R4SqJ5121IHm7VSx2DWytSFC6ePMcCOYi9aQrY8hTXtW8nv9STcoBVP+Y3E+cAUjcdgaY3v/AEpCLXose1rd37ameSFAqKvFy/mkgQI6f7aNwqUoOkGVEgJ8zaR7mg8G6lINvEZg8htXKkzQPhPFfxjk/v3/ANK/N4lBYbaxDMaCSYGhUmBqOoQSRIP/AEm1L8VjGdJX3agUWbUSVaUbnmSTcTy+dcQ8SQXFqWRtrUogeW9FrPeIVKucQSTx3iB03pCFWOI8uQmeYfS5IFlT7jj8xWVsrUvSk7pAF95gVlUFAZWaTe55LAa+SWOpvArHDHratsKkzWYhNNeVPZ0EhWfs3jEpbUrvlIUBZI4nh+Qat+d5kwloIQVKLhCpUSpaQCFFN7gbW2+deY5aqDJEgXiKfvvh1IlIQUgRFuM+5Jqb2ZtGGUig3lNO8Egne49yJ+cUHnjLakJNp1WPmD/SgFOecWN7kAjn0JI/6hyqDGLVp03gQR14CPzgamAvonyAtIcOUlUg6lajzvHXcUwydWk/FAkXm88iJmPl71C8SYHD6Gf7VM0naN6sXLwxpiTjkL07snmXicw+rUy4DpSZlEjxROyLm3TzrzbFfEQL3NxtvwqyZcy20y6pSC44ttSU6FApTIiQCYPnvGwqrYVKlGCLzEcZ5fnI1IDutTA+MbHCrUOJw+rzqD91lKYMk+w86MxbKkC4O0/r96DYdAGkkpBIMj1keW3tVWcLFrWgO4ypsLhJKmwrcxqgaZBHWYkCtIcUgaDuCTHImJPsBTbIcvddURhklaykyYCUo6lRMT051tORgwXyW3Dq8M+I6DpIjgoEEad7US8BZ4oHSmmpKrFfl67y/EHUJ58KZ4zIQllTiFEwJhSYMfUGJpVg3SiVAXAsYBjrcWpgQeEJoHwkB4q0XmSNb6hwBCfYX26zU7WUIWqdRAIEBMQLcz5G/nUWSwnUVSVEEzBMTbV7n5VccL2I71vWxiEiwII8SYUOcyN/lUy4A5Wh8Z9JoHPJVKzHLw1GlRUDc2FhwuNxfe3Ch0KppnTy21qYnUoSFkRA0gzFhIi80iUaNWhFIWhHBdMGcUkiOPkPvSIOGenS1dBwg/0oFi1N1Xsi8U5Cges1lQOkkAG+9/b+lZXUk3lpNIdhVT6qFQaKCJAiZ6x7imKhE41QUrDfIwTYnoYIP/dAPQ0SjFGDJkgaTPLb9KBcBQATF+HTjVx7FMtLbXrI/iHSqYki8bggnc2G/wAldwrRyCN+B2SJtwkwN7jnuTbrYm1bQXCDysDKxI8+QmTw3rMWhWFfLawCLXj4km4WL/l6mxuOAvqAI2Bv7RceY50pFLZFK2QFxdVfRKnQQqDHI39af5MYGoRPPj69Kqb+JKjJM/Xp9BReBxsHcjy/uKLmGlHTatjZCrdrcW82lpJVM6kjbTEFR4CJBv8AehO1+QrwykvFxB1KPhQTKCBIJneY36UE5mpSAW16VcwCCPzzNKsxxy1DSpRVJkk3P506VzAQU2veHtI3Y5+qzHZgp2CbAAWG08T5k0OgiASPMVw2lcSAdPExt+ldtjhT1XCwh5kNuXpXYZrC6dQUA4gpIg6QtJGyrSSFAyOopr2lzHDrw+JcUyCsWS7AkLQYASeHit1mvJ8Ni3GVBbSik9Pz50W9mbrqQlaiGwZ0SYJ5nhU3Ms3adpN7QFaSpCml6lABaPFFvFpgkekewqkvJUhSkBUpMXAseI8vKiX8YYjhynfe/wA6gxhEISLHj5/pTMBC0a6SOSsZC6wrxStPkRHO0wek3q/ZexhwWnB3iSEgHQ4lKtQ31xNjvE8drV5uSoKBTYg/OmuHzBxRkp1RGwAHskCa5wwszbc6gFbM4xOGC++QBqWolwlJ8IHhABj4SINrG5vIqj5lhQ24UjbceXKnyXg4lWuZIhU73Ebb7RsIEUjzRyQg8kjzM8/QfOlZyteoY1sX5/lAaTMQR510COM+lEuYVZAcCSEniRaoXIHU1Xled8HK6Lg0xvcRMSOf2rK57g8SkHkSZ+kVlDCqS7uELXaXIqXG4QtmDccDzodKSdhNNgrMQ5jqPKkUvV+c6aZJmfdOJUYAA46uHGxmYpejAuG4SfW1RLQRYiKGDhMdw6iCmvaPNv3h3XeAkJE7kCTJ9SaWJuYG5qOa7aF6NUErSSUd/wAmUUyFJJ5X+RpekEGPQ1d8rwDZRMrJgC1r8wCNr8ZtSPOcuOsx8Q35EcD+faph57rW6GN4uK7Hbz8kpC6iWZqZ7CqTwkcxtQ5qgpZpdw6XKVjEqQZB/Q9DXS3JNrVCymSATAkX5dab4vJ4SVNqKo4Hf0j6UCQDlNHHI9pLeyCS/f4QbQLchHCK7efUngB+db0GDWTRpJ6hqgpHXZ5+tRTXJrdFK51otDnP34/1ohh4pMpv9DS9JtUwcm/2A+lIQtMUpBToOGNR8I5CT9TalOKVrXp4T9qnwQUsxqISN4/PyKjxTIQrwk35xSCgaWuXdJGHV03lWnBqCkglMGII4f2qt5hhktvGR4TcDl0p7k2EUoWIHhnxDl0H5al+atKWShQhaImL2I3HoRbpSN6StE8sc7QB8Q4S1bgINrmtVE6gpOk7/Ucx0rKqAvPe6zlO8Q1KYUkweYP4KhZShI5fnzpllmL7xWkROnZVwocQPc/Kl2bI0qKQAAbjpeI9xU67LRHqA42RlbVixwpesa7EVFrv1qIPqJ3inDUks4OHKFaIMVIz9624QVGP72vVs7Gfs/xWZIccw6mQG1BKu8WpJkibQg2iqLC0AZ7LWUYjxJTe8jzsIj2+ZonN8M4pwpDSyWwUuEJJ0kazpXyUEocMH+RXKnPZT9muYKV3zf7tOHxC0DWtX+IwspkDuyCkKFp5bU0yXsvneLbOKacw7TeKQmUrMKW2G1tpKglspEoWVecHcUmxUZNscCFTFZLihI/dXjCgg/w1WUrZJt8RJFqR43JH+8CUsOaiJ0hJm7vcgjzdIR/qtvXpY7NZy9iMS6VsB7DvNrXeNS2mlrQpEIIIKHzyubgRYbAdl81cbwZC8KoYlEtqclbhRr/fdLyiglXjExe8jY0WtpPNOZRRpecM5NiJc/gO/wAJIU4NCvAlSdQK7eHwyq/AE8DVjwmUYpJ0Kwr4V/L3S+Xl0I8xG9W9zsNm6MSpoPYTvcUhbxJO6mghpbgPc+F0h8yRvrUTcCiCMyThXcZiHWO7Q6W1TBJcbxSkWSURAeAKbj4AbRXOF8pYZnRfDS8vzfInh/ESy5pVB+BUeLu44ce9a/8AUTzFLncqfStKFMuBalltKSg6lLSrQUARJUFeGOdeo9lGs0xqcQth5rumlt6g4ACVtIaKVQGyCR3Dd7bHmamzXspmjqsCrXhCt10LZWQAoLSyXpUQ3YFLckCQVR50WnsllaHW8UPZeZJ7L40wBhXjJIHgVcpmYteIPtXLfZvGGCMK8fFp+BW+kLjb+RQV0BmvYHOzefB5po4jChau9cQUzaICpluJ/i7kEm8nnFlPZvO3e8DbuHAZfIKlkpBcbbQ0oo0oKinShKZMGQSL3o2pBli7Xl7GSyYdlJBgp2UCLEKnYjlUGbZeGoKZ0kwZ4eXSvX8r7BY3vnW30YdS1DvVq/yLLi1fB4NpBlJAi0TNqj+0rss7gkpLqWkpeCtKW1qUAW4JN0JgQU2HWpdVraJIS3YG0fKpGFxxSNMCPz3qPEvlR1cooXVFdhVNtzaX13Fm0nhWzIcU3Mrj4SRY3mLCN6AxOYjvFLAsIQOoTYE9eHkBSZt9SQQFEA8K2vEEgJgW2jegWron7Du7qfNcQFwR5Vld4LBJUQFAmNwDzrK7c1uFV0Esx34/KXsYhSSCDBFwaIxuNLhB2gQAPM/O9c4XAlQBNgdo3P2Fd4nL1AFQkjrvHpvTEi1lbFIG7gMIQORXBVXNZTqBcStg175/w8v6cFjFxOl0GJjZsV4FXtf7GXSjJs1WndKXFDzGHJFchfZewZI2GtTYHxu4l0nqXyduuvfpVYyZZGCyGCRKmQYO4/5e+YPMSAfSrFhswDmN0DhhEOjyecUB/wCOknZPBnEZfk621oKWO6Wu/wDLhXWSkQD4gtYkGNj5VyCa5U6E4rHkif4zA/7mGk/egGsKGV5SyNmi41/6eFcR/wDjQ+NzINjOXkEKLKkKt/M1hm1R5gj3ptnUfvmXFOxceNuuGcM1y5UDP4wfaPC4j96DgxLimlsjdnU022kK8R+JSkq2T8PGt/trxv7pgmcMmJexL7xG/h7xbk+ep5J8xVb/AGq5A6xnTGKUpBRisQ2Wwkq1jue4SrXKQBciIJ9KN/4j1xiMH/8Aac/3poFO2rCaf8PydWDxoKo1OCSeEtm5+tXbGMBtzJ2woLCHFJChsoJy/EDULmx33qifsCVOBx/+r/8AUauiNsj8/wD+c/XBc85NIXD5aG+0CnhiUuF7DuSwN2e7ThU38R+MeLYetbyPNGHzjsvD4bxKcW8oJJhRBd7wKSJGpPAxcQekw4Xs+6z2kcxalILeKw6+7AKtY7lOFQrWCkAX2gn0o/LMGnEMYxtso71ONdkndJD4cEkAkHTBHmKKW0qxGcPnOsIziWO5VCwgoWXGnUFtxWoK0pggpI0kT6EE+dftllecOJUTpDbaQJt4kCSOAMV6P2rxg/8AiHK2kqEhDxWkRIBbXpn2PtXl/wC2t4pzh6P5Gv8AxppSMK0JbvFrz/MMKWllJuOB5j8tUAXReNxWtKRyP4B8qmwWVarrJA5DehdDKcxF0hbFwhGEaiBsOdFgpQJA8UX41zj8MWSNJlJm/HyNArWTXVaYOMVhw6kbgl3kkg86yoMKYM1lI4ZWqCToymeDXYAUS6bUHljfORPKjMa3CCsTAMGSOl/mLcvagRlczUNAopevLEm6SQPegMVhSg3uOdMlP6Yi4N6iViiTEUwJUpYoiMYKV1sLIsCa6eRBIrEtHfYVW1g2m6Wg6rmfc1tt5SfhUR5EijMOBEWvwisVg0k8fSl3hWGmcRYRjvZ11ODTiw42UKAJbBX3iUqcdaStQKQggrZWICidpAmosJk7zmFexaVDu2FISoFStRLhIBSIiBabj4hvTrN8xUcBhcI0pGkNnvvCO81JxWIWhClb6QlwKAFpVNTZNmGHRlWIwrjml13vlATAHdqwi0JUNNyotuAEERB3kQQQVJ8bmfEEn7Ndm3sd3hbdbSW9A/iKWCpTmoJSjSlQklJuYG16F7P5UvGPpYDqG1KB0l0uaTAmPAhRBgE7RberL+zPOmcOnEh1xLanO6S2pSdWhUOgOixEoUpCvSkfYbGNs45lxxQQhJVKjsJbUPqRRSJTBCilK9QkjUnUEqj/ADCQDB6gHpTTs/2fxGLxDeGbUApcwpalBA0pJuQCRYRtuQKXYFIKgCYnjV77EYxvB4lDjkqQotpUvWEd2kPtOFc6FahCIKYEpKri1KTlWDWlueV573yv5j7msbeIMhRB5gkGu8W2AolIISSdIJkgciYEmOMDyqJNMpkFporeozN558anSytW/uajZtejEYqBt7UpJ7K0TGnLio3AAR0HzpzgHPD1pEtUyaa4bDBSTESBPXyHGd6RwsLQyb03YC3m41I8rj0/pSCm7bmpRQTPD0No/rQ+MyxSJIun5+tFuMFLqGmX+40IRlapgca3UncFBBMfnzrdEnwkjZjqJRWBeix529aIzjFBXhTYGCaTpXzrfedK4tzakHhSzArSQSJF6gUqa2lRGxNNSBkNogQSVGJ2HSKjecmoZrad66kTJYpE4c0TMU1VlKELAgwpyBc/DoJjz1CoUpb1LSpsgoQVwFzsAYkDjIrP6gPC9gaKSMU8gZrv2z4S04nhUWKR4ZO9Nv3Jsln+GYc0yrXtMmNPkN6XstJ0OqVJ0KRaTsVEEewp2uHZZpoX/C4g2D57Dd48eEtqRDJN4sKYZxhW2ilKJJMqm/wk+Ee1Qrju0m8lSwb8giPqacPsAhZHaYxvc1/bx9P5UWHMKqw4FaSlUmCDaTwI28t61lPYnE4hvDuoU0Evu90jUpUgnXC1gJMNlTTiQb3bVan2G/Z9ikp7wfu65Tqbu8Csd2pyRqZ/h2SofxNFx1EkhS3C1UFNJkiLSYB4XoV7L/5TTztT2ffwYR3ymz3ilgd2VG6AhRmUi38RMeRoXOcgdYaYfLja0P6gjQVzKQgkeJCQoDWBqQVJkETIpQCFpc+NzQCLSXTAg2IraDWsSo6r8hWmz1plEEB1LtQt8qIRjbXQCY3P1oafz5fatVy45ypcO7pOqi14kuDTtS+anw6iPEPalI7q0TyBt7LMURYC8VlRKrKISuObWk4cmtnBqpspI/OdRPPDYXpd5VjpGNGUqcaKd60lsnYE+Qpg1pMg35VvEORCU8eX0FNuUHQNFm8IJvDKPTzqZzAFIkGYvEf1prgMAlSTqJCiLEEwPbeOtRYtotnSVBU3B+xoFyDGRnH5XLufyQdFkuFYk8CkiNuZJmgf34BSihsJCkFESTvxvxrrHYUAahbmKCArmsb2Tz6rUF1PP4H8ItOPVrbXAlsADe8Tv71IcxT4h3QAUUFQBN9KieM7zFCjDqOyTUjWCUbwI6miWtSsln4H+PIrx4wpsfj++0ymFAkTw0kyB6bUUhpJQlEbEmfMJHval5VCotTNraaQigAFqicZHOc82Tz9P/EyZ7cY/D6G0PANtpbS2goSUJ7tQUlQEfHIMq3OozvQOD7X4xtCkB4qStSlOBfj7zU13RDmqdadFoO0Ai4FAYxkrICd6DcYUn4gRVAbCxyx7XGhhWDNO2WJxLam3gysGSFFlvWkqCQdColEhCduVB47P3n2m2l92ltslQDbSG5WUhJcXpA1K0pSJPLnS0QEnnWYYCRO0/auSHBCNCUKSAryBgj2NL8SzoMexq24QpKAkxoiCN99gd7byaV4rDJSpTR8QF0zvpO3qNqQOpWI9XBwfKQ6q6BpsMAhXType7hFJJHKnDgUj9PIz3CjSRXU1Ck10TRpIHromsrlJrK6kN4TbEfD6UIj4T+cK1WVIcL0JOR8lpr4qnb/AMVHr9DWVlMs5+A/NWHgr/SP9tI8w3T6/wC41lZXBTZyFrF/CaWjY1lZRbwn1HxhMMq3/OYohHwDyH3rKypu5W2H4B8v4St3/E/OVORt7fSsrKL+ylpuXfNBJ/xE/nOj3/hNbrKB5CvH8LkgXufOtsbisrKsvGHKteQ/Er/SP/Iulmc/4yP9J+9arKn3KszkLpn4qixfx+g+prdZSd16h+D6pKv4j51qsrK0LxDyuk1usrKCC//Z",
                //Cast = new List<string>
                //{
                //    "Alvaro Morte",
                //    "Pedro Alonso",
                //    "Miguel Herran"
                //}
                Cast="Alvaro, Pedro, Miguel"

            };
            Movies.Add(movie);
            Movies.Add(movie2);
        }

        

        public List<Movie> GetAll()
        {
            //var temp = JsonConvert.SerializeObject(Movies);  za da pretvorime vo JSON file
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.ID == id);
        }

        
    }
}
