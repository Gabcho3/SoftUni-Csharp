function censoreWord(text, word){
    while(text.includes(word)){
        text = text.replace(word, '*'.repeat(word.length));
    }
    console.log(text);
}
censoreWord('A small sentence with some words', 'small'); //A ***** sentence with some words