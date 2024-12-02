namespace BelugaAPI.Provider.Providers.Results;
public class Tool
{
    public string type { get; set; }
}

public class TruncationStrategy
{
    public string type { get; set; }
    public object last_messages { get; set; }
}

public class RunResult
{
    public string id { get; set; }
    public string @object { get; set; }
    public long created_at { get; set; }
    public string assistant_id { get; set; }
    public string thread_id { get; set; }
    public string status { get; set; }
    public long? started_at { get; set; }
    public long? expires_at { get; set; }
    public long? cancelled_at { get; set; }
    public long? failed_at { get; set; }
    public long? completed_at { get; set; }
    public string last_error { get; set; }
    public string model { get; set; }
    public string instructions { get; set; }
    public object incomplete_details { get; set; }
    public List<Tool> tools { get; set; }
    public Dictionary<string, object> metadata { get; set; }
    public object usage { get; set; }
    public double temperature { get; set; }
    public double top_p { get; set; }
    public int? max_prompt_tokens { get; set; }
    public int? max_completion_tokens { get; set; }
    public TruncationStrategy truncation_strategy { get; set; }
    public string response_format { get; set; }
    public string tool_choice { get; set; }
    public bool parallel_tool_calls { get; set; }
}


public class ThreadResult
{
    public string id { get; set; }
    public string @object { get; set; }
    public long created_at { get; set; }
    public Dictionary<string, object> metadata { get; set; }
    public Dictionary<string, object> tool_resources { get; set; }
}