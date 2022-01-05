using System.Collections.Generic;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;

public class ThankService : IThankService
{
    private readonly IndexedDBManager dbManager;

    public ThankService(IndexedDBManager dbManager)
    {
        this.dbManager = dbManager;
    }

    public Task<IEnumerable<ThanksNote>> GetPreviousThanks(int amount)
    {
        throw new System.NotImplementedException();
    }

    public Task<ThanksNote> GetRandomThanks()
    {
        throw new System.NotImplementedException();
    }

    public async Task SaveThanks(ThanksNote note)
    {
        var record = new StoreRecord<ThanksNote>
        {
            Storename = "ThanksNotes",
            Data = note,
        };
        await dbManager.AddRecord(record);
    }
}

public interface IThankService 
{
    Task SaveThanks(ThanksNote note);

    Task<ThanksNote> GetRandomThanks();

    Task<IEnumerable<ThanksNote>> GetPreviousThanks(int amount);
}