function countStringOccurrences(text, word){
    let occurrences = 0;
    text = text.split(' ');
    while(text.includes(word)){
        occurrences++;
        let index = text.indexOf(word);
        text.splice(index, index);
    }
    console.log(occurrences);
}
countStringOccurrences('This is a word and it also is a sentence', 'is'); //2