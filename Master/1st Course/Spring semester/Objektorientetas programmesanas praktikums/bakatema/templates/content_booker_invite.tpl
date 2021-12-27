<form name="booker_invite" action="{$formaction}" method="POST">
<input type="hidden" name="page" id="page" value="{$nextpage}" />
	<div class="post">
		<h1 class="title">
			<a>Vadītāju saraksts</a>
		</h1>
		<br/>
		{if $data_lecturers|@count == 0}
			<div class="text">
				<span>Neviens ieraksts nav atrasts. </span>
				<a href="javascript:location.reload(true)">Atjaunot datus.</a>
			</div>
		{else}
			<div class="right" align="center">
				<table width="600" cellspacing="0" cellpadding="0">
					<tr class="head">
						<td>Vadītājs</td>
						<td align="center">Maksimālais studentu skaits</td>
						<td align="center">Izvēlēties</td>
					</tr>
					{foreach from=$data_lecturers item=lecturer}
						<tr>
							<td>{$lecturer.name}</td>
							<td align="center">{$lecturer.qoute}</td>
							<td align="center">
								<input name='identities[]' type="checkbox"
									value="{$lecturer.id}">
							</td>
						</tr>
					{/foreach}
				</table>
				<div class="action_block">
					<button name="invite" type="submit">Aicināt vadītājus</button>
				</div>
			</div>
		{/if}
	</div>
</form>
