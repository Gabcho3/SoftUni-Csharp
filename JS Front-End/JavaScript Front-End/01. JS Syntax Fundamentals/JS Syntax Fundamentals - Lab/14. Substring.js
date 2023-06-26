function getSubstring(word, startIndex, count){
    let subString = word.substring(startIndex, startIndex + count);
    console.log(subString);
}
getSubstring("ASentence", 1, 8); //Sentence
getSubstring("JavaScript", 4, 6); //Script