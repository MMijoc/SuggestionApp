namespace SuggestionApp.Library.DataAccess;

public interface ISuggestionData
{
	Task CreateSuggestion(SuggestionModel suggestion);
	Task<List<SuggestionModel>> GetAllApprovedSuggestions();
	Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApproval();
	Task<SuggestionModel> GetSuggestion(string id);
	Task<List<SuggestionModel>> GettAllSuggestions();
	Task UpadteSuggestion(SuggestionModel suggestion);
	Task UpvoteSuggestion(string suggestionId, string userId);
}