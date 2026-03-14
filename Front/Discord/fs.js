import fs from 'fs/promises';
import path from 'path';
import chalk from 'chalk';
import { pathToFileURL } from 'url';
import client from './index.js';

export default async (client) => {

  // Загрузка событий
  try {
    const files = await fs.readdir(path.resolve("./events/"));
    const jsfiles = files.filter(f => path.extname(f) === ".js");

    if (jsfiles.length === 0) return console.log("There are no events to load...");
    console.log(chalk.bgWhite(chalk.black(`Loaded ${jsfiles.length} events...`)));

    for (const f of jsfiles) {
      const eventPath = path.resolve(`./events/${f}`);
      await import(pathToFileURL(eventPath)); 
    }

  } catch (err) {
    console.error(err);
  }

  // Загрузка команд
  try {
    const files = await fs.readdir(path.resolve("./commands/"));
    const jsfiles = files.filter(f => path.extname(f) === ".js");

    if (jsfiles.length === 0) return console.log("There are no commands to load...");
    console.log(chalk.bgWhite(chalk.black(`Loaded ${jsfiles.length} commands...`)));

    for (const f of jsfiles) {
      const commandPath = path.resolve(`./commands/${f}`);
      const props = await import(pathToFileURL(commandPath));

      client.commands.set(props.help.name, props);
      props.help.aliases.forEach(alias => {
        client.aliases.set(alias, props.help.name);
      });
    }

  } catch (err) {
    console.error(err);
  }
};
