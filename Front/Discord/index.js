import { Client, Collection, Events, GatewayIntentBits, MessageFlags } from 'discord.js';
import TOKEN from './authds.json' with {"type": "json"};
import request from 'request';

import fs from 'fs';
import { fileURLToPath } from 'url';
import {dirname} from 'path';
import path from 'path';


// Dz
const {tokends} = TOKEN;
const CLIENT_ID = "1482073842724896959";
const client = new Client({ intents: [GatewayIntentBits.Guilds] });
const __dirname = dirname(fileURLToPath(import.meta.url));
// Dzend

// Filesystem (fs)

client.commands = new Collection();


const foldersPath = path.join(__dirname, 'cmds');
const commandFolders = fs.readdirSync(foldersPath);

(async () => {
  for (const folder of commandFolders) {
    const commandsPath = path.join(foldersPath, folder);
    const commandFiles = fs.readdirSync(commandsPath).filter(file => file.endsWith('.js'));

    for (const file of commandFiles) {
      const filePath = path.join(commandsPath, file);

      const commandModule = await import(`file://${filePath}`);
      const command = commandModule.default ?? commandModule;

      if ('data' in command && 'execute' in command) {
        client.commands.set(command.data.name, command);
      } else {
        console.log(`[WARNING] The command at ${filePath} is missing a required "data" or "execute" property.`);
      }
    }
  }
})();

// Fsend

// Events

// Startup
client.on(Events.ClientReady, readyClient => {
  console.log(`Logged in as ${readyClient.user.tag}!`);
});

// Interaction - Message
client.on(Events.InteractionCreate, async interaction => {
  if (!interaction.isChatInputCommand()) return;
  if(interaction.user.bot) return;

  const command = interaction.client.commands.get(interaction.commandName);
	if (!command) {
		console.error(`No command matching ${interaction.commandName} was found.`);
		return;
	}
	try {
		await command.execute(interaction);
	} catch (error) {
		console.error(error);
		if (interaction.replied || interaction.deferred) {
			await interaction.followUp({
				content: 'There was an error while executing this command!',
				flags: MessageFlags.Ephemeral,
			});
		} else {
			await interaction.reply({
				content: 'There was an error while executing this command!',
				flags: MessageFlags.Ephemeral,
			});
		}
	}

});

// Eventsend

client.login(tokends);


import { REST, Routes } from 'discord.js';

const commands = [
  {
    name: 'ping',
    description: 'Replies with Pong!',
  },
];

// var myJSONObject = { name:'moyhuy',VideoUrl:'mybigpensil',MapName:'Oregon'};
// console.log(myJSONObject)
// request({
//     url: "http://localhost:5000/api/strats",
//     method: "POST",
//     json: true,
//     body: myJSONObject
// }, function (error, response, body){
//     if (error) {
//         console.error('Ошибка:', error);
//     } else if (response.statusCode !== 200) {
//         console.error('Статус ответа:', response.statusCode);
//         console.log('Ответ тела:', body);
//     } else {
//         console.log('Успех:', body);
//     }
// });



const rest = new REST({ version: '10' }).setToken(tokends);


try {
  console.log('Started refreshing application (/) commands.');

  await rest.put(Routes.applicationCommands(CLIENT_ID), { body: commands });

  console.log('Successfully reloaded application (/) commands.');
} catch (error) {
  console.error(error);
}


