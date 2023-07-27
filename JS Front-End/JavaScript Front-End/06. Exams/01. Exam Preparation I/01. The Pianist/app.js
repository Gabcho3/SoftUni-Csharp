function createListOfPianoPieces(input) {
  const numOfPieces = Number(input.shift());

  class Piece {
    constructor(name, composer, key) {
      this.name = name;
      this.composer = composer;
      this.key = key;
    }
  }

  let pieces = [];

  for (let i = 0; i < numOfPieces; i++) {
    const [name, composer, key] = input[0].split("|");

    const piece = new Piece(name, composer, key);
    pieces.push(piece);

    input.shift();
  }

  while (true) {
    const [command, ...pieceData] = input.shift().split("|");

    if (command === "Stop") {
      printPieces(pieces);
      return;
    }

    const pieceName = pieceData.shift();
    const pieceMatch = pieces.find((piece) => piece.name === pieceName);

    switch (command) {
      case "Add":
        const [composer, key] = pieceData;

        if (pieceMatch) {
          console.log(`${pieceName} is already in the collection!`);
        } else {
          pieces.push(new Piece(pieceName, composer, key));
          console.log(
            `${pieceName} by ${composer} in ${key} added to the collection!`
          );
        }
        break;

      case "Remove":
        if (pieceMatch) {
          pieces.splice(pieces.indexOf(pieceMatch), 1);
          console.log(`Successfully removed ${pieceName}!`);
        } else {
          console.log(
            `Invalid operation! ${pieceMatch} does not exist in the collection.`
          );
        }
        break;

      case "ChangeKey":
        if (pieceMatch) {
          const newKey = pieceData.shift();
          pieceMatch.key = newKey;
          console.log(`Changed the key of ${pieceName} to ${newKey}`);
        } else {
          console.log(
            `Invalid operation! ${pieceName} does not exist in the collection.`
          );
        }
        break;
    }
  }

  function printPieces(pieces) {
    pieces.forEach((piece) => {
      console.log(
        `${piece.name} -> Composer: ${piece.composer}, Key: ${piece.key}`
      );
    });
  }
}
createListOfPianoPieces([
  "3",
  "Fur Elise|Beethoven|A Minor",
  "Moonlight Sonata|Beethoven|C# Minor",
  "Clair de Lune|Debussy|C# Minor",
  "Add|Sonata No.2|Chopin|B Minor",
  "Add|Hungarian Rhapsody No.2|Liszt|C# Minor",
  "Add|Fur Elise|Beethoven|C# Minor",
  "Remove|Clair de Lune",
  "ChangeKey|Moonlight Sonata|C# Major",
  "Stop",
]);
createListOfPianoPieces([
  "4",
  "Eine kleine Nachtmusik|Mozart|G Major",
  "La Campanella|Liszt|G# Minor",
  "The Marriage of Figaro|Mozart|G Major",
  "Hungarian Dance No.5|Brahms|G Minor",
  "Add|Spring|Vivaldi|E Major",
  "Remove|The Marriage of Figaro",
  "Remove|Turkish March",
  "ChangeKey|Spring|C Major",
  "Add|Nocturne|Chopin|C# Minor",
  "Stop",
]);
