function storeInfoAboutLeadersAndArmies(input) {
  const leadersWithArmies = {};
  for (let i = 0; i < input.length; i++) {
    const element = input[i];

    if (element.includes("arrives")) {
      moveLeader(leadersWithArmies, element, "arrives");
    } else if (element.includes("defeated")) {
      moveLeader(leadersWithArmies, element, "defeated");
    } else if (element.includes(":")) {
      addArmy(leadersWithArmies, element);
    } else if (element.includes("+")) {
      addCountToArmy(leadersWithArmies, element);
    }
  }

  calculateTotalArmyCount(leadersWithArmies);
  printLeadersWithArmies(leadersWithArmies);
}

function moveLeader(leadersWithArmies, element, action) {
  const index = element.indexOf(" " + action);
  const leader = element.substring(0, index);

  if (action === "arrives") {
    leadersWithArmies[leader] = [];
  } else {
    delete leadersWithArmies.leader;
  }
}
function addArmy(leadersWithArmies, element) {
  const [leader, armyData] = element.split(": ");
  const [armyName, armyCount] = armyData.split(", ");
  const army = {
    name: armyName,
    count: Number(armyCount),
    getArmy() {
      return this.name + " - " + this.count;
    },
  };

  if (leadersWithArmies.hasOwnProperty(leader)) {
    leadersWithArmies[leader].push(army);
  }
}
function addCountToArmy(leadersWithArmies, element) {
  const [armyName, armyCount] = element.split(" + ");
  const keys = Object.keys(leadersWithArmies);

  keys.forEach((key) => {
    leadersWithArmies[key].forEach((army) => {
      if (army.name === armyName) {
        army.count += Number(armyCount);
      }
    });
  });
}
function calculateTotalArmyCount(leadersWithArmies) {
  for (const leader in leadersWithArmies) {
    let totalArmyCount = 0;
    const armies = leadersWithArmies[leader];
    armies.forEach((army) => {
      totalArmyCount += army.count;
    });

    leadersWithArmies[leader]["totalArmyCount"] = totalArmyCount;
  }
}
function printLeadersWithArmies(leadersWithArmies) {
  let entries = Object.entries(leadersWithArmies);
  entries.sort((a, b) => b[1]["totalArmyCount"] - a[1]["totalArmyCount"]);

  for (const [leader, army] of entries) {
    console.log(leader + ": " + army["totalArmyCount"]);
    let values = Object.values(army);
    values.pop(); //removing ["totalArmyCount"]
    values.sort((a, b) => b.count - a.count);

    values.forEach((army) => {
      console.log(">>> " + army.getArmy());
    });
  }
}
storeInfoAboutLeadersAndArmies([
  "Rick Burr arrives",
  "Fergus: Wexamp, 30245",
  "Rick Burr: Juard, 50000",
  "Findlay arrives",
  "Findlay: Britox, 34540",
  "Wexamp + 6000",
  "Juard + 1350",
  "Britox + 4500",
  "Porter arrives",
  "Porter: Legion, 55000",
  "Legion + 302",
  "Rick Burr defeated",
  "Porter: Retix, 3205",
]);
storeInfoAboutLeadersAndArmies([
  "Rick Burr arrives",
  "Findlay arrives",
  "Rick Burr: Juard, 1500",
  "Wexamp arrives",
  "Findlay: Wexamp, 34540",
  "Wexamp + 340",
  "Wexamp: Britox, 1155",
  "Wexamp: Juard, 43423",
]);
