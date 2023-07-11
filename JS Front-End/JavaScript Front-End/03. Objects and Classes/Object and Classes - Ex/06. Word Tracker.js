function trackWords(input){
    const wordsToTrack = input.shift().split(/\s+/);
    let trackedWords = input.reduce((acc, curr) => {
        if(wordsToTrack.includes(curr) && !Object.keys(acc).includes(curr)){
            acc[curr] = 0;
            const index = wordsToTrack.indexOf(curr);
            wordsToTrack.splice(index, index + 1);
        }
        if(Object.keys(acc).includes(curr)){
            acc[curr]++;
        }
        return acc; 
    }, []);
    trackedWords = Object.entries(trackedWords).sort((a, b) => b[1] - a[1]);
    for(const [word, occurrences] of trackedWords){
        console.log(`${word} - ${occurrences}`);
    }
    wordsToTrack.forEach(word => console.log(`${word} - 0`));
}
trackWords([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task'
    ]
    );
trackWords([
    'is the',
    'first', 'sentence', 'Here', 'is',
    'another', 'the', 'And', 'finally', 'the',
    'the', 'sentence']);