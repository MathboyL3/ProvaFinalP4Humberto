﻿using MongoDB.Bson;
using MongoDB.Driver;
using Revisao.Data.Interfaces;
using Revisao.Data.Mongo;
using Revisao.Data.Mongo.Interfaces;
using System.Linq.Expressions;

namespace Revisao.Data
{
	public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument

	{
		private readonly IMongoCollection<TDocument> _collection;

		 public MongoRepository(IMongoSettings settings)
		{
			var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
			_collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
		}

		private protected string GetCollectionName(Type documentType)
		{
			return ((CollectionNameAttribute)documentType.GetCustomAttributes(
					typeof(CollectionNameAttribute),
					true)
				.FirstOrDefault())?.Name;
		}

		public virtual IQueryable<TDocument> AsQueryable()
		{
			return _collection.AsQueryable();
		}

		public virtual IEnumerable<TDocument> FilterBy(
			Expression<Func<TDocument, bool>> filterExpression)
		{
			return _collection.Find(filterExpression).ToEnumerable();
		}

		public virtual IEnumerable<TProjected> FilterBy<TProjected>(
			Expression<Func<TDocument, bool>> filterExpression,
			Expression<Func<TDocument, TProjected>> projectionExpression)
		{
			return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
		}

		public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
		{
			return _collection.Find(filterExpression).FirstOrDefault();			
		}

		

		public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
		{
			return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
		}

		public virtual TDocument FindById(string id)
		{
			var objectId = new ObjectId(id);
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, objectId);
			return _collection.Find(filter).SingleOrDefault();
		}

		public virtual Task<TDocument> FindByIdAsync(string id)
		{
			return Task.Run(() =>
			{
				var objectId = new ObjectId(id);
				var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, objectId);
				return _collection.Find(filter).SingleOrDefaultAsync();
			});
		}


		public virtual void InsertOne(TDocument document)
		{
			_collection.InsertOne(document);
		}

		public virtual Task InsertOneAsync(TDocument document)
		{
			return Task.Run(() => _collection.InsertOneAsync(document));
		}

		public void InsertMany(ICollection<TDocument> documents)
		{
			_collection.InsertMany(documents);
		}


		public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
		{
			await _collection.InsertManyAsync(documents);
		}

		public void ReplaceOne(TDocument document)
		{
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, document.id);
			_collection.FindOneAndReplace(filter, document);
		}

		public virtual async Task ReplaceOneAsync(TDocument document)
		{
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, document.id);
			await _collection.FindOneAndReplaceAsync(filter, document);
		}

		public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
		{
			_collection.FindOneAndDelete(filterExpression);
		}

		public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
		{
			return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
		}

		public void DeleteById(string id)
		{
			var objectId = new ObjectId(id);
			var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, objectId);
			_collection.FindOneAndDelete(filter);
		}

		public Task DeleteByIdAsync(string id)
		{
			return Task.Run(() =>
			{
				var objectId = new ObjectId(id);
				var filter = Builders<TDocument>.Filter.Eq(doc => doc.id, objectId);
				_collection.FindOneAndDeleteAsync(filter);
			});
		}

		public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
		{
			_collection.DeleteMany(filterExpression);
		}

		public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
		{
			return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
		}
	}
}