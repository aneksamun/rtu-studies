<form name="booker_order" action="{$formaction}" method="POST">
<input type="hidden" name="page" id="page" value="{$nextpage}" />
	<div class="post">
		<h1 class="title">
			<a>Apstiprināto tēmu saraksts</a>
		</h1>
		<br/>
		{if $approvedTitles|@count == 0}
			<div class="text">
				<span>Neviens ieraksts nav atrasts. </span>
				<a href="javascript:location.reload(true)">Atjaunot datus.</a>
			</div>
		{else}
			<div class="right">
				<table width="100%" cellspacing="0" cellpadding="0">
					<tr class="head">
						<td>Tēmas nosaukums</td>
						<td>Tēmas nosaukums svešvalodā</td>
						<td>Vadītājs</td>
						<td>Students</td>
						<td align="center">Izvēlēties</td>
					</tr>
					{foreach from=$approvedTitles item=title}
						<tr>
							<td>{$title.native_title}</td>
							<td>{$title.broad_title}</td>
							<td>{$title.lecturer}</td>
							<td>{$title.student}</td>
							<td align="center">
								<input type="checkbox" />
							</td>
						</tr>
					{/foreach}
				</table>
				<div class="order_action">
					<button name="order" type="submit" onclick="javascript:alert('Funkcija taps izstrādes 2. stadijā'); return false;">Veidot rīkojumus</button>&nbsp;
					<button name="task" type="submit" onclick="javascript:alert('Funkcija taps izstrādes 2. stadijā'); return false;">Sastadīt uzdevumus</button>
				</div>
			</div>
		{/if}
	</div>
</form>