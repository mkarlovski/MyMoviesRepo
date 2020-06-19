function ValidateComment() {
    var comment = document.getElementById("comment").value;
    if (comment == null || comment == " ") {
        alert("Please enter comment");
        return false;
    } else {
        return true;
    }
}

function MovieLike(movieId) {
    axios.post('/movielikes/like', { //ova mu e pateka do kontroler i endpoint
        movieId: movieId
    }).then(function (response) {
        console.log(response);
    }).catch(function (error) {
        console.log(error)
        alert("Something went wrong!!!")
    });
}

function MovieDislike(movieId) {
    alert("Disliked" + movieId)
}