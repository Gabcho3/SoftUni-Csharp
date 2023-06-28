function findValidHashtags(text){
    let textToArray = Array.from(text.split(' '));
    let listOfHashtags = [];
    
    textToArray.forEach(word => {
        if(word[0] == '#' && word.length > 1){
            listOfHashtags.push(word.substring(1, word.length));
        }
    })

    let validHashatags = listOfHashtags.map(hashtag => {
            if(/\d/.test(hashtag) || /\W/.test(hashtag)){
                return null
            } else{
                return hashtag;
            }
        });
    console.log(validHashatags.join('\n').trim());
}
findValidHashtags('Nowadays everyone uses # to tag a #special word in #socialMedia'); //special | socialMedia
findValidHashtags('The symbol # is known #variously in English-speaking #regions as the #number sign');