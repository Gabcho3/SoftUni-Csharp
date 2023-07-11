function storeMovies(input){
    let movies = [];
    for(let i = 0; i < input.length; i++){
        const element = input[i];
        const movie = {};

        if(element.includes('addMovie')){
            const index = element.indexOf(' ');
            movie.name = element.substring(index + 1);
        } else if(element.includes('directedBy')){
            setPropertyToMovie(movies, element, 'directedBy');
        } else{
            setPropertyToMovie(movies, element, 'onDate');
        }

        if(movie.hasOwnProperty('name')){
            movies.push(movie);
        }
    }
    printMovies(movies);
}

function setPropertyToMovie(movies, element, command){
    const index = element.indexOf(command) + command.length;
    const name = element.substring(0, element.indexOf(' ' + command));
    const property = element.substring(index + 1);
    const currMovie = movies.find(movie => movie.name === name);
    const key = command === 'onDate' ? 'date' : 'director';
    if(currMovie != undefined){ currMovie[key] = property; }
}

function printMovies(movies){
    movies.forEach(movie => {
        if(Object.keys(movie).length === 3){
            console.log(JSON.stringify(movie)); 
        }
    });
}
storeMovies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);