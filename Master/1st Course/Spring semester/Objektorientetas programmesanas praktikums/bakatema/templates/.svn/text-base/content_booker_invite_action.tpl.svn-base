<form name="content_invite_action" action="{$formaction}" method="POST">
	<input type="hidden" name="page" id="page" value="{$nextpage}"/>
	<div class="post">
		<h1 class="title">
			<a>Aicināt vadītājus</a>
		</h1>
		{if not $mode}
			<div class="text">
				<b>{$status}</b><br/>
				<button class="top_space" type="submit" name="back">Uz galveno</button>
			</div>
		{elseif $mode eq send_email}
			<br/>
			<div class="text">
				<table cellspacing="0" border="0">
					<tr>
						<td class="spacing cell_size" valign="top"><b>E-pasts/-i:</b></td>
						<td class="bottom_space" align="left">
							{foreach from=$lecturers item=lecturer}
								{$lecturer.email};
								<input type="hidden" name='lecturersIds[]' value="{$lecturer.id}" />
								&nbsp;
							{/foreach}
						</td>
					</tr>
					<tr>
						<td colspan="2"><b>Teksts:</b></td>
					</tr>
					<tr>
						<td colspan="2" class="bottom_space">
							<textarea rows="6" style="width:97%;">{$file_content}</textarea> 
							<input type="hidden" name="invite_text" value="{$file_content}" />
						</td>
					</tr>
					<tr>
						<td align="right" colspan="2">
							<div style="float: right">
								<button type="submit" name="send">Sūtīt</button>
								<button type="submit" name="back">Uz galveno</button>
							</div>
						</td>
					</tr>
				</table>
			</div>
		{/if}
	</div>
</form>