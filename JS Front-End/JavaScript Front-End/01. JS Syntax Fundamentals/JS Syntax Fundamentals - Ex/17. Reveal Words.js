function revealWords(wordsToReveal, string){
    let words = wordsToReveal.split(', ');
    let stringToArray = string.split(' ');

    for (let i = 0; i < stringToArray.length; i++) {
        const currWord = stringToArray[i];

        if(currWord[0] === '*'){
            words.forEach(wordToReveal => {
                if(wordToReveal.length == currWord.length){
                    stringToArray[i] = wordToReveal;
                }
            });
        }
    }
    console.log(stringToArray.join(' '));
}
revealWords('great', 'softuni is ***** place for learning new programming languages');