function trackRace(input) {
  let horses = input.shift().split("|");

  while (true) {
    const [command, ...rest] = input.shift().split(" ");

    if (command === "Finish") {
      break;
    }

    const horseName = rest[0];
    const currPosition = horses.indexOf(horseName);
    switch (command) {
      case "Retake":
        retake(...rest, currPosition);
        break;

      case "Trouble":
        trouble(horseName, currPosition);
        break;

      case "Rage":
        rage(horseName, currPosition);
        break;

      case "Miracle":
        overtakeAllHorses();
        break;
    }
  }

  function retake(overtaking, overtaken, currPosition) {
    const overtakenHorsePosition = horses.indexOf(overtaken);

    if (overtakenHorsePosition > currPosition) {
      horses[currPosition] = overtaken;
      horses[overtakenHorsePosition] = overtaking;

      console.log(`${overtaking} retakes ${overtaken}.`);
    }
  }

  function trouble(horseName, currPosition) {
    if (currPosition > 0) {
      const overtakingHorse = horses[currPosition - 1];
      horses[currPosition] = overtakingHorse;
      horses[currPosition - 1] = horseName;

      console.log(`Trouble for ${horseName} - drops one position.`);
    }
  }

  function rage(horseName, currPosition) {
    const horsesToOvertake = [];

    if (currPosition + 1 < horses.length) {
      horsesToOvertake.push(horses[currPosition + 1]);
    }
    if (currPosition + 2 < horses.length) {
      horsesToOvertake.push(horses[currPosition + 2]);
    }

    let horsesToString = horses.join("|");

    for (let i = 0; i < horsesToOvertake.length; i++) {
      const currHorse = horsesToOvertake[i];
      horsesToString = horsesToString.replace(currHorse, horseName);
      horsesToString = horsesToString.replace(horseName, currHorse);
    }

    horses = horsesToString.split("|");

    console.log(`${horseName} rages 2 positions ahead.`);
  }

  function overtakeAllHorses() {
    const positionsToOvertake = horses.length - 1;

    for (let i = 0; i < positionsToOvertake; i++) {
      const currHorse = horses.pop();
      horses.unshift(currHorse);
    }
    console.log(`What a miracle - ${horses[horses.length - 1]} becomes first.`);
  }

  console.log(horses.join("->"));
  console.log(`The winner is: ${horses[horses.length - 1]}`);
}
trackRace([
  "Bella|Alexia|Sugar",
  "Retake Alexia Sugar",
  "Rage Bella",
  "Trouble Bella",
  "Finish",
]);
trackRace([
  "Onyx|Domino|Sugar|Fiona",
  "Trouble Onyx",
  "Retake Onyx Sugar",
  "Rage Domino",
  "Miracle",
  "Finish",
]);
trackRace([
  "Fancy|Lilly",
  "Retake Lilly Fancy",
  "Trouble Lilly",
  "Trouble Lilly",
  "Finish",
  "Rage Lilly",
]);
