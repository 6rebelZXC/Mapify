import client from '../index.js';
import chalk from 'chalk';
import { Client, Collection, Events, GatewayIntentBits, MessageFlags } from 'discord.js';

client.on(Events.ClientReady, readyClient => {
  console.log(chalk.rgb(255, 255, 255).bgGreenBright.bold(`{Event:ready} - ${readyClient.user.tag}!`));
});