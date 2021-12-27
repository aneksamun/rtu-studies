<form name="bach_action" action="{$formaction}" method="POST">
	<input type="hidden" name="page" id="page" value="{$nextpage}"/>
	
	<div class="post">
		<h1 class="title">
			<a>{$status}</a>
		</h1>
		<br/>
		
		<div class="right">
			{if $mode}
				<div class="text">
					<b>Tēmas nosaukums: </b>{$title->title}<br/>
				</div>
			{/if}
			{if $mode eq approve_data}
				<div class="text">
					<b>Komentārs:</b><br/>
					<textarea rows="8" name="approval_coment" style="width:80%;"></textarea>
				</div>
				<button name="approve" type="submit" value="{$title_id}">Apstiprināt</button>
			{elseif $mode eq refuse_data}
				<div class="text">
					<b>Atteikuma pamatojums:</b><br/>
					<textarea rows="8" name="refusal_reason" style="width:80%;"></textarea>
				</div>
				<button name="refuse" type="submit" value="{$title_id}">Atteikt</button>
			{/if}
			<button name="back" type="submit">Atpakaļ</button>
		</div>
	</div>
	<br/>&nbsp
</form>