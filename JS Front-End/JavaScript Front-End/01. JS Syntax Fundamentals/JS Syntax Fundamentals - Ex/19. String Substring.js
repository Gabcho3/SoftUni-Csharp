function findSubstring(word, text){
    let wordToLower = word.toLowerCase();
    let textToLower = text.toLowerCase();

    if(textToLower.includes(wordToLower)){
        console.log(word);
    }else{
        console.log(`${word} not found!`);
    }
}
