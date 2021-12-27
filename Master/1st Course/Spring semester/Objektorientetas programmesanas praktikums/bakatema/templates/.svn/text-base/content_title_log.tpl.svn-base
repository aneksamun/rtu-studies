<form name="title_log" action="{$formaction}" method="POST">
	<input type="hidden" name="page" id="page" value="{$nextpage}"/>
	
	<div class="post">
		<h1 class="title">
			<a>Tēmas izmaiņas:</a>
		</h1>
		<br/>
		
		<div class="right">
			{if $data_log_lv|@count == 0}
				<div class="text">
					<span>Tēmas latviešu valodā izmaiņu ierakstu nav.</span>
				</div>
			{else}
				<div>
					<p>Tēmas latviešu valodā izmaiņas</p>
					<table width="100%" cellspacing="0" cellpadding="0">
						<tr class="head">
							<td>Revīzija</td>
							<td>Izmaiņu datums</td>
							<td>Komentārs</td>
						</tr>
						{foreach from=$data_log_lv item=i_entry}
						<tr>
						    <td>{$i_entry->revisionNumber}</td>
						    <td>{date( 'd-m-Y', $i_entry->revisionDate)}</td>
						    <td>{$i_entry->comment}</td>
						</tr>
						{/foreach}
					</table>
				</div>
			{/if}
			<br/>
			{if $data_log_en|@count == 0}
				<div class="text">
					<span>Tēmas angļu valodā izmaiņu ierakstu nav.</span>
				</div>
			{else}
				<div>
					<p>Tēmas angļu valodā izmaiņas</p>
					<table width="100%" cellspacing="0" cellpadding="0">
						<tr class="head">
							<td>Revīzija</td>
							<td>Izmaiņu datums</td>
							<td>Komentārs</td>
						</tr>
						{foreach from=$data_log_en item=i_entry}
						<tr>
						    <td>{$i_entry->revisionNumber}</td>
						    <td>{date( 'd-m-Y', $i_entry->revisionDate)}</td>
						    <td>{$i_entry->comment}</td>
						</tr>
						{/foreach}
					</table>
				</div>
			{/if}
			<br/>
			<button name="back" type="submit">Atpakaļ</button>
		</div>
	</div>
	<br/>&nbsp
</form>