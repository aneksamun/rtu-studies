<form name="bach_home" action="{$formaction}" method="POST">
	<input type="hidden" name="page" id="page" value="{$nextpage}"/>
	<div class="post">
		<h1 class="title"><a>Nepieciešamo izskatīšanai tēmu saraksts:</a></h1>
		<br/>
		{if $data_titles|@count == 0}
			<div class="text">
				<span>Uz doto brīdi šādu tēmu nav.</span>
				<a href="javascript:location.reload(true)">Atjaunot datus</a>
			</div>
		{else}
			<div class="right">
				<table width="100%" cellspacing="0" cellpadding="0">
					<tr class="head">
						<td>Tēmas nosaukums</td>
						<td>Pēdējo izmaiņu datums</td>
						<td>Mācībspēks</td>
						<td>Studenti</td>
						<td>Darbības</td>
					</tr>
					{foreach from=$data_titles item=i_title}
					<tr>
					    <td>{$i_title.native_title}</td>
					    <td>{$i_title.revision_date}</td>
					    <td>{$i_title.lecturer_name}</td>
					    <td>
						    {foreach from=$i_title.applied_students item=i_student}
						    	{$i_student->firstName} {$i_student->lastName}<br/>
						    {/foreach}
					    </td>
					    <td>
					    	<button name="start_approve" type="submit" value="{$i_title.title_id}">Apstiprināt</button>
					    	<button name="start_refuse" type="submit" value="{$i_title.title_id}">Noraidīt</button>
					    	<button name="info" type="submit" value="{$i_title.title_id}">Vairāk info...</button>
					    </td>
					</tr>
					{/foreach}
				</table>
			</div>
		{/if}
		<br/>&nbsp
	</div>
</form>