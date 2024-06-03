import { test, expect } from "@playwright/test";

//Verify if user can add a task
test("user can add a task", async ({ page }) => {
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  const taskText = await page.textContent(".task");
  expect(taskText).toContain("Test Task");
});

//Verify if user can delete a task
test("user can delete a task", async ({ page }) => {
  //Add a task
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  //Delete the task
  await page.click(".delete-task");

  const tasks = await page.$$eval(".task", (tasks) =>
    tasks.map((task) => task.textContent)
  );

  expect(tasks).not.toContain("Test Task");
});

//Verify is user can set a task as completed
test("user can complete a task", async ({ page }) => {
  //Add a task
  await page.goto("http://localhost:5500/");
  await page.fill("#task-input", "Test Task");
  await page.click("#add-task");

  //Complete the task
  await page.click(".task-complete");

  const completedTask = await page.$(".task.completed#task-0");
  expect(completedTask).not.toBeNull();
});
