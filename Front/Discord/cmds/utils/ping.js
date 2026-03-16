import { SlashCommandBuilder } from 'discord.js';
export default {
	async execute(interaction) {
		await interaction.reply('Pong!');
	},
};