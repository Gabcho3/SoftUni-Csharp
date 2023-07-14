function storeSequencesOfNumbers(input) {
  const sortedNumbers = input.reduce((acc, curr) => {
    let parsed = JSON.parse(curr);
    parsed = parsed.sort((a, b) => b - a);

    acc.push(parsed);
    return acc;
  }, []);

  for (let i = 0; i < sortedNumbers.length; i++) {
    const currArray = sortedNumbers[i];

    for (let j = i + 1; j < sortedNumbers.length; j++) {
      const nextArray = sortedNumbers[j];

      if (JSON.stringify(currArray) === JSON.stringify(nextArray)) {
        const indexToRemove = sortedNumbers.lastIndexOf(nextArray);
        sortedNumbers.splice(indexToRemove, 1);
        i = -1;
      }
    }
  }

  sortedNumbers.sort((a, b) => a.length - b.length);
  sortedNumbers.forEach((array) => console.log(`[${array.join(", ")}]`));
}

storeSequencesOfNumbers([
  "[-3, -2, -1, 0, 1, 2, 3, 4]",
  "[10, 1, -17, 0, 2, 13]",
  "[4, -3, 3, -2, 2, -1, 1, 0]",
]);
storeSequencesOfNumbers([
  "[7.14, 7.180, 7.339, 80.099]",
  "[7.339, 80.0990, 7.140000, 7.18]",
  "[7.339, 7.180, 7.14, 80.099]",
]);
