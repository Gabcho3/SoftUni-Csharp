function findWordsWithOddOccurrences(input){
    const words = input.toLowerCase().split(' ').reduce((acc, curr) => {
        if(!Object.keys(acc).includes(curr)){
            acc[curr] = 1;
        } else{
            acc[curr]++;
        }
        return acc;
    }, {});
    
    const filteredWords = Object.keys(words).filter(value => words[value] % 2 != 0);
    console.log(filteredWords.join(' '));
}
findWordsWithOddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
findWordsWithOddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');