function createShoppingList(input) {
  const products = input.shift().split("!");
  const list = [];

  products.forEach((product) => {
    list.push(product);
  });

  for (let i = 0; i < input.length; i++) {
    const [command, item, newItem] = input[i].split(" ");
    const index = list.indexOf(item);

    switch (command) {
      case "Urgent":
        if (!list.includes(item)) {
          list.unshift(item);
        }
        break;

      case "Unnecessary":
        if (index != -1) {
          list.splice(index, 1);
        }
        break;

      case "Correct":
        for (let i = 0; i < list.length; i++) {
          if (i === index) {
            list[i] = newItem;
          }
        }
        break;

      case "Rearrange":
        const itemMatch = list.find((product) => product === item);
        if (itemMatch) {
          list.splice(index, 1);
          list.push(item);
        }
        break;
    }
  }
  console.log(list.join(", "));
}
createShoppingList([
  "Tomatoes!Potatoes!Bread",
  "Unnecessary Milk",
  "Urgent Tomatoes",
  "Go Shopping!",
]);
createShoppingList([
  "Milk!Pepper!Salt!Water!Banana",
  "Urgent Salt",
  "Unnecessary Grapes",
  "Correct Pepper Onion",
  "Rearrange Grapes",
  "Correct Tomatoes Potatoes",
  "Go Shopping!",
]);
